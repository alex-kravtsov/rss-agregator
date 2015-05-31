### RSS Агрегатор

Данная программа написана для тестирования возможностей построения настольного приложения на C# с использованием классов пространства имён System.Windows.Forms в операционной системе Linux.

В самой идее нет ничего особенного. Это просто интерфейс к базе данных, в которую собирается информация из публичных RSS-лент. Использована база данных проекта автопостинга для аккаунта в Twitter. Программа выводит записи новостных лент из базы данных, показывая из какого источника получено сообщение, дату сообщения, заголовок и содержание. Если есть картинка, то она будет выведена вместе с содержанием новости. В каждой записи имеется кликабельная ссылка на полный текст новости на сайте-источнике.

Особенность программы в наборе инструментов, использованных для её реализации. .NET Framework, пространство имён System.Windows.Forms, C#. Довольно обычный набор для реализации настольных приложений под Windows. Но эта программа сделана только с использованием средств Linux: Для сборки использовался компилятор Mono, демо-версия запущена в среде Mono Runtime. Для подключения к базе данных MySQL использована свободно распространяемая библиотека MySQL.Data.dll.

Оценивая полученный результат, следует отметить, что приложение работает именно так, как ожидалось. Одако, есть один существенный недостаток. Приложение очень долго загружается при запуске (минуты). Это при том, что в нём совсем немного кода, да и объём данных весьма невелик - записи новостных лент в базе данных ежечасно обновляются, но одновременно в ней хранится всего около 150 записей.