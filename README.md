# StarStaffLibrary

Проект является реализацией тестового задания по написанию библиотеки, вычисляющей площадь прямоугольного треугольника, принимая на вход длину трех его сторон.

Поскольку работа с double-ами подразумевает некоторую точность вычислительных операций, то для учета точности вводится класс **Precision**, содержащий набор методов-операций на double-ами.

Класс **Triangles** в конструкторе принимает на вход экземпляр класса Precision и использует его для вычисления площади прямоугольного треугольника. Таким образом, пользователи библиотеки могут указывать желаемую точность. Метод вычисления площади осуществляет проверку длин сторон на корректность. 

Проект включает в себя unit тесты для вышеозвученых классов. Тесты написаны под NUnit.
