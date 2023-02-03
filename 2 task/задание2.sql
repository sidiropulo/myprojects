

create table jsonb_test (
           id serial primary key, 
		   data jsonb
)

разработать таблицу  в БД для хранения статичных данных используемых затем в приложениях для показа в интерфейсе пользователя 
как текстовые поля, а так же как имена различных контролов.
Например:
 необходимо в пользовательском интерфейсе
 вывести в label  фразу "Дата выпуска", 
а свойство Name  для label назначить "date1"., 

так вот как это хранить в бд, 
если таких записей может быть много и они используются для построения динамического пользовательского интерфейса.
Подсказка: json.

вставки, изменения, удаления.


INSERT INTO jsonb_test (data) VALUES 
('{"button_id": "label1", "config": {"name": "date2", "textval": "Меню"}}')


INSERT INTO jsonb_test (data) VALUES 
('{"button_id": "pushbutton", "name": "click", "textval": "Завершить"}')


        
   
SELECT * FROM jsonb_test WHERE data ->> 'textval' = 'Дата выпуска';
 
 SELECT * FROM jsonb_test