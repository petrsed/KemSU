import telebot
import requests
from telebot.types import *
from datetime import datetime

bot = telebot.TeleBot("")

def send_urls(chat_id, msg_id=None):
    markup = InlineKeyboardMarkup()
    markup.add(InlineKeyboardButton("QA", callback_data="urls_QA"))
    markup.add(InlineKeyboardButton("ML", callback_data="urls_ML"))
    markup.add(InlineKeyboardButton("Web", callback_data="urls_Web"))
    if msg_id is None:
        bot.send_message(chat_id, f"1) Ссылки на сайты\nВыбеирет сферу:", reply_markup=markup)
    else:
        bot.edit_message_text(f"1) Ссылки на сайты\nВыбеирет сферу:", chat_id, msg_id, reply_markup=markup)

def logging_message(user_id, user_name, message):
    print(f"{datetime.now()} - {user_id} - {user_name} - {message}")

def check_message_type(message):
    if message.content_type == "voice":
        bot.send_message(message.chat.id, "Это голосовое сообщение!")
    else:
        bot.send_message(message.chat.id, "Это НЕ голосовое сообщение!")

def dialog_name(message):
    name = message.text
    msg = bot.send_message(message.chat.id, f"Отлично, {name}! Сколько вам лет?")
    bot.register_next_step_handler(msg, dialog_age, name)

def dialog_age(message, name):
    age = message.text
    msg = bot.send_message(message.chat.id, f"{name}, {age}: у меня есть несколько персональных подборок по ипотеке для вас! Обратитесь в банк!")
    bot.register_next_step_handler(msg, dialog_age, name)

@bot.callback_query_handler(func=lambda call: True)
def callback_query(call):
    logging_message(call.from_user.id, call.from_user.username, call.data)
    chat_id, username, data = call.from_user.id, call.from_user.username, call.data
    if "urls_" in data:
        url_type = data.split("_")[1]
        markup = InlineKeyboardMarkup()
        if url_type == "QA":
            markup.add(InlineKeyboardButton("Software-Testing", url="https://www.software-testing.ru/"))
            markup.add(InlineKeyboardButton("QA-Guide", url="https://qa-guide.ru/"))
            markup.add(InlineKeyboardButton("LearnQA", url="https://www.learnqa.ru/"))
        elif url_type == "ML":
            markup.add(InlineKeyboardButton("MachineLearningWiki", url="http://www.machinelearning.ru/wiki/index.php?title=Машинное_обучение"))
            markup.add(InlineKeyboardButton("SberCloud", url="https://sbercloud.ru/ru/warp/machine-learning-about"))
            markup.add(InlineKeyboardButton("Vas3k", url="https://vas3k.com/blog/machine_learning/"))
        elif url_type == "Web":
            markup.add(InlineKeyboardButton("Glo Academy", url="https://glo.academy/"))
            markup.add(InlineKeyboardButton("HTML Academy", url="https://htmlacademy.ru/?utm_source=yandex&utm_medium=cpc&utm_campaign=ru_brand_49458608&utm_content=v2%7C%7C9217660746%7C%7C21051916802%7C%7CHTML%20academy%7C%7C1%7C%7Cpremium%7C%7Cnone%7C%7Csearch%7C%7Cno&utm_term=HTML%20academy&yclid=8356987209977167871"))
            markup.add(InlineKeyboardButton("WAYUP", url="https://wayup.in/"))
        markup.add(InlineKeyboardButton("Назад", callback_data="urls"))
        bot.edit_message_text(f"1) Ссылки на сайты\n{url_type}:", chat_id, call.message.id, reply_markup=markup)
    elif data == "urls":
        send_urls(chat_id, call.message.id)



@bot.message_handler(commands=['help', 'start'])
def command_handler(message):
    logging_message(message.chat.id, message.from_user.username, message.text)
    chat_id, username, text = message.chat.id, message.from_user.username, message.text
    keyboard = ReplyKeyboardMarkup(resize_keyboard=True)
    keyboard.add("1) Ссылки на сайты")
    keyboard.add("2) Реагирование на голосовые сообщения")
    keyboard.add("3) Простой диалог")
    keyboard.add("4) Удаление клавиатуры", "5) Работа с API")
    bot.send_message(chat_id, "Здравствуйте!", reply_markup=keyboard)


@bot.message_handler(func=lambda message: True)
def message_handler(message):
    logging_message(message.chat.id, message.from_user.username, message.text)
    chat_id, username, text = message.chat.id, message.from_user.username, message.text
    if "1)" in text:
        send_urls(chat_id)
    elif "2)" in text:
        msg = bot.send_message(chat_id, "Пришлите сообщение:")
        bot.register_next_step_handler(msg, check_message_type)
    elif "3)" in text:
        msg = bot.send_message(chat_id, "Здравствуйте! Как вас зовут?")
        bot.register_next_step_handler(msg, dialog_name)
    elif "4)" in text:
        keyboard = ReplyKeyboardRemove()
        bot.send_message(chat_id, "Клавиатура удалена! (повторный вызов клавиатуры - /start)", reply_markup=keyboard)
    elif "5)" in text:
        request = requests.get("https://reqres.in/api/users/2")
        if request.status_code == 200:
            data = request.json()["data"]
            msg = F"Информация о пользователе:\n\nID - {data['id']}\nEmail - {data['email']}\nИмя - {data['first_name']}\nФамилия - {data['last_name']}\n\n<a href='{data['avatar']}'>Аватар</a>"
            bot.send_message(chat_id, msg, parse_mode="HTML")
        else:
            bot.send_message(chat_id, "Сервер вернул ошибку!")


while True:
    try:
        bot.polling()
    except Exception:
        pass
