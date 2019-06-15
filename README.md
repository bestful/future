Future

# Задания

**Илья**:
- [x] скопировать актульную инфу с задач и алексея
-  сформировать облако тезисов
- делаем крутые инновации
- 

**Олег**:
- [x] выпиши известные алгоритмы поиска пути
- [x] поищи библиотеки на python и ссылки на документацию к ним
- [ ] построить прототип маршрута из точки а в точку б на javascript

**Алексей**:

- [ ] работа над прототипом 
  - [x] промо-страница
  - [ ] авторизация/регистрация
  - [ ] меню сервера
- формирование userflow

# Актуальная инфа

## Прооблема
- Сложность вхождения в крупные торговые сети местных
производителей
- Низкая конкурентоспособность региональных производителей в
сфере сбыта из-за отсутствия развитой инфраструктуры
- Повышение степени прозрачности работы экономических
агентов в регионе

## Базовая задача
Создать прототип электронной площадки (возможно,
геоинформационной системы) с возможностью создания профилей
«поставщик», «покупатель»

## Обязательная часть
Сервис должен обеспечивать:
- Возможность создания профиля поставщика с геопривязкой на
карте региона, указанием производимых товаров (текст, фото,
видео)
- Возможность регистрации покупателя и его геолокации на карте
- Обеспечение работы поисковой системы по товарам и адресам

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
- 
- Руководитель:	ГЕНЕРАЛЬНЫЙ ДИРЕКТОР КОБЫЛЯНСКИЙ МАКСИМ ВЛАДИМИРОВИЧ
ИНН / КПП:	7802599293 / 780201001
Уставной капитал:	300 тыс.
Численность персонала:	42
Количество учредителей:	1
Дата регистрации:	08.11.2016
Статус:	Действующее


stockFor_productIn_location:
- product_id
- location
- count
- price


## Связи

Поля со связями
- person-> contactFor_person
- location -> linkIn_System
- stockFor_productIn_location
