import psycopg2
from config import host, user, password, db_name


def get_translate(some_text):
    connector = None
    try:
        connector = psycopg2.connect(
            host=host,
            user=user,
            password=password,
            database=db_name
        )
		connector.autocommit = True
        engine = connector.cursor()

        engine.callproc('ru_to_eng', [some_text, ])

        print("Отправка запроса")
        result = engine.fetchall()
        for row in result:
            print("Получение запроса: = ", row[0], )

    except (Exception, psycopg2.DatabaseError) as error:
        print("Ошибка подключения", error)

    finally:

        # closing database connection.
        if connector:
            engine.close()
            connector.close()
            print("подключение завершено")


def menu():
    print("Введите действие")
    print("1 - перевод")
    print("2 - выход")
    select_int = int(input("Введите номер: "))
    if select_int == 1:
        print("Введите фразу: ")
        some_txt = input()
        get_translate(some_txt)
        menu()
    if select_int == 2:
        exit()
    else:
        print("not found")
        exit()


menu()