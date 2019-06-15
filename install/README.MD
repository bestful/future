## Утсановка
- https://git-scm.com/download/win
- https://code.visualstudio.com/Download

## Копирование репозитория
- Заходим в ~/Documents 
- git clone git@github.com:bestful/future.git

## Глобальная настройка
- git config --global user.name "Ilya Kataev"
- git config --global user.email "kataev.i@gmail.com"

## Генерация ключа

**Если его нет в ~/Documents, то**
- Заходим в ~/Documents
- ssh-keygen -t rsa -b 4096 -C "kataev.i@gmail.com"
Filename: id_rsa

## Проверка авторизации
Проверка
- ssh -vT git@github.com

