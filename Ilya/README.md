
# Реляционная модель

## Таблицы основные

*Основные*
- person
- location
- product
- company

## Таблицы сложные
*Дополнительные:*

(данные поля используются для функциональности)

- contactFor_person
- companyFor_person

*Кешируемые:*
(данные поля можно присобачить ко всему)
- linkIn_System (для тегов и поиска по ним)

## Видовые таблицы

- user (person + contact)
- place (location + tags)
- access ()


## Поля

- [x] person:
  - Имя
  - Пароль

- [x] location:
  - Ширина
  - Долгота
  - *Адрес*

- [x] product:
  - name
  - *manufacturer*

- [x] companyFor_person
  - person_id (director)
  - name

- [X] stockFor_productIn_location:
  - product_id
  - location
  - count
  - price


## Связи

Поля со связями
- person-> contactFor_person
- location -> linkIn_System
- stockFor_productIn_location
