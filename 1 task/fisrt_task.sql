CREATE TABLE ru_eng (
 id SERIAL PRIMARY KEY,
 ru_word text,
 en_word text )
 
create or replace function ru_to_eng(str text)
  returns text
  language plpgsql
  as $$
    declare
      out_text text;
    begin
     out_text := translate(
        trim(both ' ' from  (str)),
        'абвгдеёзийклмнопрстуфыэАБВГДЕЁЗИЙКЛМНОПРСТУФЫЭ',
        'abvgdeeziyklmnoprstufyeABVGDEEZIYKLMNOPRSTUFYE'
      );
      out_text := replace(out_text, 'ж', 'zh');
      out_text := replace(out_text, 'х', 'kh');
      out_text := replace(out_text, 'ц', 'ts');
      out_text := replace(out_text, 'ч', 'ch');
      out_text := replace(out_text, 'ш', 'sh');
      out_text := replace(out_text, 'щ', 'sch');
      out_text := replace(out_text, 'ь', ' ');
      out_text := replace(out_text, 'ъ', ' ');
      out_text := replace(out_text, 'ю', 'yu');
      out_text := replace(out_text, 'я', 'ya');
      out_text := REPLACE(out_text, 'Ж', 'ZH');
      out_text := REPLACE(out_text, 'Х', 'KH');
      out_text := REPLACE(out_text, 'Ц', 'TS');
      out_text := REPLACE(out_text, 'Ч', 'CH');
      out_text := REPLACE(out_text, 'Ш', 'SH');
      out_text := REPLACE(out_text, 'Щ', 'SCH');
      out_text := REPLACE(out_text, 'Ь', ' ');
      out_text := REPLACE(out_text, 'Ъ', ' ');
      out_text := REPLACE(out_text, 'Ю', 'YU');
      out_text := REPLACE(out_text, 'Я', 'YA');
      INSERT INTO ru_eng(ru_word, en_word) VALUES (str, out_text);
      return out_text;
    end
  $$;