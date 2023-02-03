import psycopg2
from config import host, user, password, db_name


def json_data():
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
        print('Выберете дейсвтие: ')
        print('1 - Добавление json ')
        print('2 - Удаление json по названию кнопки  ')
        print('3 - Удаление json по id')
        print('4 - Обновление json по id')
        print('5 - Выход')
        q = '"'
        t = ':'
        ls = '{'
        rs = '}'
        selected_number = int(input())
        # call stored procedure
        # {"button_id": "label", "name": "date1", "textval": "Дата"}
        match selected_number:
            case 1:
                print('Введите название кнопки (button id)')
                button_id = input()
                print('Введите имя кнопки (name)')
                name = input()
                print('Введите текст кнопки (textval)')
                textval = input()
                add_json = ls + q + "button_id" + q + t + q + button_id + q + ',' + q + "name" + q + t + q + name + q + ',' + q + "textval" + q + t + q + textval + q + rs
                print(add_json)
                engine.callproc('created_json', [add_json, ])

            case 2:
                print("Введите название кнопки для удаления(button id)")
                delete_name = input()
                engine.callproc('delete_json_by_button', [delete_name, ])

            case 3:
                print('Введите id json для удаления')
                id_json = int(input())
                engine.callproc('delete_json_by_id', [id_json, ])
            case 4:
                print('Введите id json для обновления')
                id_json = input()
                print('Введите название кнопки (button id)')
                button_id = input()
                print('Введите имя кнопки (name)')
                name = input()
                print('Введите текст кнопки (textval)')
                textval = input()
                update_json = ls + q + "button_id" + q + t + q + button_id + q + ',' + q + "name" + q + t + q + name + q + ',' + q + "textval" + q + t + q + textval + q + rs
                engine.callproc('update_json_by_id', [id_json, update_json])
            case 5:
                exit()
            case _:
                print('case_')

    except (Exception, psycopg2.DatabaseError) as error:
        print("Error con", error)

    finally:

        # closing database connection.
        if connector:
            engine.close()
            connector.close()
    json_data()


json_data()
