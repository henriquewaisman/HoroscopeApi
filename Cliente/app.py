from flask import Flask, render_template, request, redirect, url_for, session
import sqlite3
import requests

app = Flask(__name__)
app.secret_key = "secret_key" 

BASE_URL = "http://localhost:5289/api"

PLAN_ACCESS = {
    "bronze": ["bronze"],
    "silver": ["bronze", "silver"],
    "gold": ["bronze", "silver", "gold"]
}

ENDPOINT_LABELS = {
    "bronze": "Mensal",
    "silver": "Semanal",
    "gold": "Diário"
}

VALID_SIGNS = [
    "aries", "taurus", "gemini", "cancer", "leo", "virgo",
    "libra", "scorpio", "sagittarius", "capricorn", "aquarius", "pisces"
]

def init_db():
    conn = sqlite3.connect("users.db")
    cursor = conn.cursor()
    cursor.execute('''
    CREATE TABLE IF NOT EXISTS users (
        username TEXT PRIMARY KEY,
        password TEXT NOT NULL,
        nickname TEXT NOT NULL,
        plan TEXT NOT NULL
    )
    ''')
    cursor.execute("SELECT COUNT(*) FROM users")
    if cursor.fetchone()[0] == 0:
        users = [
            ("joao", "1234", "Joãozinho", "gold"),
            ("ana", "abcd", "Aninha", "silver"),
            ("pedro", "senha", "Pedrão", "bronze")
        ]
        cursor.executemany("INSERT INTO users VALUES (?, ?, ?, ?)", users)
        conn.commit()
    conn.close()

def get_user(username, password):
    conn = sqlite3.connect("users.db")
    cursor = conn.cursor()
    cursor.execute("SELECT nickname, plan FROM users WHERE username=? AND password=?", (username, password))
    row = cursor.fetchone()
    conn.close()
    return row

def get_horoscope(plan, sign):
    url = f"{BASE_URL}/{plan}horoscope/{sign}"
    try:
        response = requests.get(url)
        response.raise_for_status()
        return response.json()
    except requests.exceptions.RequestException:
        return None

@app.route("/register", methods=["GET", "POST"])
def register():
    if request.method == "POST":
        username = request.form["username"].lower()
        password = request.form["password"]
        nickname = request.form["nickname"]
        plan = request.form["plan"].lower()

        if plan not in PLAN_ACCESS:
            return "❌ Plano inválido.", 400

        conn = sqlite3.connect("users.db")
        cursor = conn.cursor()
        cursor.execute("SELECT * FROM users WHERE username=?", (username,))
        if cursor.fetchone():
            conn.close()
            return render_template("register.html", error="Usuário já existe.")

        cursor.execute("INSERT INTO users (username, password, nickname, plan) VALUES (?, ?, ?, ?)",
                       (username, password, nickname, plan))
        conn.commit()
        conn.close()

        return redirect(url_for("login"))
    return render_template("register.html", error=None)


@app.route("/", methods=["GET", "POST"])
def login():
    if request.method == "POST":
        username = request.form["username"].lower()
        password = request.form["password"]
        user = get_user(username, password)
        if user:
            session["nickname"], session["plan"] = user
            return redirect(url_for("menu"))
        else:
            return render_template("login.html", error="Usuário ou senha inválidos.")
    return render_template("login.html")

@app.route("/menu", methods=["GET", "POST"])
def menu():
    if "nickname" not in session:
        return redirect(url_for("login"))

    if request.method == "POST":
        signo = request.form["sign"].lower()
        endpoint = request.form["endpoint"]
        result = get_horoscope(endpoint, signo)
        if result:
            return render_template("result.html", nickname=session["nickname"],
                                   sign=signo, tipo=ENDPOINT_LABELS[endpoint],
                                   result=result)
        else:
            return render_template("menu.html", error="Erro ao buscar horóscopo.",
                                   valid_signs=VALID_SIGNS,
                                   endpoints=PLAN_ACCESS[session["plan"]],
                                   labels=ENDPOINT_LABELS)

    return render_template("menu.html",
                           valid_signs=VALID_SIGNS,
                           endpoints=PLAN_ACCESS[session["plan"]],
                           labels=ENDPOINT_LABELS)

@app.route("/logout")
def logout():
    session.clear()
    return redirect(url_for("login"))

if __name__ == "__main__":
    init_db()
    app.run(debug=True)
