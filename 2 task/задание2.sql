----------------------------------------------------------------------
-- таблица
----------------------------------------------------------------------
create table jsonb_test (
           id serial primary key, 
		   data jsonb
)

----------------------------------------------------------------------
--                  индекс на поле button_id (название кнопки)
----------------------------------------------------------------------

CREATE INDEX ON jsonb_test((data->>'button_id'));


----------------------------------------------------------------------
--                  вставка в таблицу
----------------------------------------------------------------------
INSERT INTO jsonb_test (data) VALUES 
('{"button_id": "label", "name": "date1", "textval": "Дата выпуска"}'),
('{"button_id": "pushbutton", "name": "click", "textval": "Завершить"}')


----------------------------------------------------------------------
--                   функция добавления в таблицу
----------------------------------------------------------------------
 create or replace function created_json(str jsonb)
  returns text
  language plpgsql
  as $$
    begin
	   INSERT INTO jsonb_test (data) VALUES 
       ( to_json(str)::jsonb);
      return str;
    end
  $$;
  
select * from  created_json
('{"button_id": "label", "name": "date1", "textval": "Дата"}')  


----------------------------------------------------------------------
--                    функция удаления по названию кнопки 
----------------------------------------------------------------------

create or replace function delete_json_by_button(str text)
  returns text
  language plpgsql
  as $$
    begin
	   delete from jsonb_test  where data ->> 'button_id' = str;
      return str;
    end
  $$;

select * from delete_json_by_button ('label') 

----------------------------------------------------------------------
--                   функция удаления по id
----------------------------------------------------------------------


create or replace function delete_json_by_id(str int)
  returns int
  language plpgsql
  as $$
    begin
	   delete from jsonb_test  where id = str;
      return str;
    end
  $$;
select * from delete_json_by_id (1) 
----------------------------------------------------------------------
--                   функция обновления по id
----------------------------------------------------------------------

create or replace function update_json_by_id(number int, str jsonb)
  returns text
  language plpgsql
  as $$
   
    begin
	   UPDATE jsonb_test
	   set data =  ( to_json(str)) where id = number;
      return str;
    end
  $$;
 
