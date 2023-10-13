
using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using OskiTest.Models;
using OskiTest.Services;
using System;
using System.Collections.Generic;
using System.Xml;


namespace OskiTest.Data
{
    public class OskiDBContext : DbContext
    {

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { set; get; } = null!;
        public DbSet<Test> Tests { set; get; } = null!;
        public DbSet<Question> Questions { set; get; } = null!;
        public DbSet<Answer> Ansers { set; get; } = null!;
        public DbSet<UserTest> UserTests { set; get; } = null!;


        public OskiDBContext(DbContextOptions<OskiDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            Role adminRole = new Role { Id = Guid.NewGuid().ToString(), RoleName = adminRoleName };
            Role userRole = new Role { Id = Guid.NewGuid().ToString(), RoleName = userRoleName };

            string adminEmail = "admin@gmail.com";
            string adminPassword = Crypto.HashPassword("123456");
            string userEmail1 = "user1@gmail.com";
            string userPassword1 = Crypto.HashPassword("123456");
            string userEmail2 = "user2@gmail.com";
            string userPassword2 = Crypto.HashPassword("123456");

            User adminUser = new User { Id = Guid.NewGuid().ToString(), UserName = "admin", Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
            User simpleUser1 = new User { Id = Guid.NewGuid().ToString(), UserName = "user1", Email = userEmail1, Password = userPassword1, RoleId = userRole.Id };
            User simpleUser2 = new User { Id = Guid.NewGuid().ToString(), UserName = "user2", Email = userEmail2, Password = userPassword2, RoleId = userRole.Id };

            Test test1 = new Test { Id = Guid.NewGuid().ToString(), TestName = "HTML test", Description = "HTML - язык разметки сайтов, без него страницы в интернете имели бы совершенно другой вид, если вообще могли бы существовать. Веб-разрабочик должен знать его на отлично. Чаще всего HTML используется в связке с CSS и JavaScript, но этот тест проверит знания именно языка разметки." };
            Test test2 = new Test { Id = Guid.NewGuid().ToString(), TestName = "PHP test", Description = "PHP — один из популярнейших скриптовых языков, используемый для web-программирования сотнями тысяч разработчиков. Тест включает в себя вопросы по базовым разделам программирования на PHP и подойдет как для тренировки профессиональным разработчикам, так и тем, кто еще только начинает изучение этого языка." };
            Test test3 = new Test { Id = Guid.NewGuid().ToString(), TestName = "Web forms test", Description = "Форма - довольно частоиспользуемый элемент при web-разработке. Через нее можно регистироваться, заполнять анкеты, оставлять обратную связь, проходить тесты и многое другое." };
            Test test4 = new Test { Id = Guid.NewGuid().ToString(), TestName = "CSS test", Description = "CSS - язык описания внешнего вида веб-документа. С помощью CSS оформлены большинство страницв интернете. Тест охватывает важные разделы CSS, без знания которых разработчику будет сложно профессионально работать в сфере." };
            Test test5 = new Test { Id = Guid.NewGuid().ToString(), TestName = "Java test", Description = "Java - объектно-ориентированный язык программирования, который часто используется для серверных приложений в крупных корпорациях, а также для web-приложений, встравиваемых систем и множества других сфер. В тесте представлены вопросы по темам, которые должен знать Junior Java-разработчик, но тест будет полезен не только новичкам, но и профессионалам для повторения." };
            Test test6 = new Test { Id = Guid.NewGuid().ToString(), TestName = "C++ test", Description = "C++ - популярный язык программирования, который применяется крупнейшими IT-корпорациями в различных областях. Тест включает в себя вопросы по основам программирования на C++ и будет полезен как начинающим для проверки своих знаний, так и профессионалам для повторения базовых тем." };

            UserTest userTests1 = new UserTest { Id = Guid.NewGuid().ToString(),UserId = simpleUser1.Id, TestId = test1.Id };
            UserTest userTests2 = new UserTest { Id = Guid.NewGuid().ToString(), UserId = simpleUser1.Id, TestId = test3.Id };
            UserTest userTests3 = new UserTest { Id = Guid.NewGuid().ToString(), UserId = simpleUser1.Id, TestId = test4.Id };
            UserTest userTests4 = new UserTest { Id = Guid.NewGuid().ToString(), UserId = simpleUser1.Id, TestId = test2.Id };
            UserTest userTests5 = new UserTest { Id = Guid.NewGuid().ToString(), UserId = simpleUser2.Id, TestId = test5.Id };
            UserTest userTests6 = new UserTest { Id = Guid.NewGuid().ToString(), UserId = simpleUser2.Id, TestId = test6.Id };
            UserTest userTests7 = new UserTest { Id = Guid.NewGuid().ToString(), UserId = simpleUser2.Id, TestId = test2.Id };

            Question question1_1 = new Question { Id = Guid.NewGuid().ToString(), TestId = test1.Id, TextQuestion = "Как правильно оставлять комментарии в HTML-коде?"};
            Question question1_2 = new Question { Id = Guid.NewGuid().ToString(), TestId = test1.Id, TextQuestion = "Документ по ссылке должен открываться в новом окне браузера. Как этого добиться?"};
            Question question1_3 = new Question { Id = Guid.NewGuid().ToString(), TestId = test1.Id, TextQuestion = "В какой атрибут тега &lt;a&gt; записывается адрес, на который пользователь переходит при нажатии на ссылку?" };
            Question question1_4 = new Question { Id = Guid.NewGuid().ToString(), TestId = test1.Id, TextQuestion = "Что помещается в тег &lt;title&gt; и где он должен располагаться?" };
            Question question1_5 = new Question { Id = Guid.NewGuid().ToString(), TestId = test1.Id, TextQuestion = "Какой тег нужно использовать, чтобы записать цифру 2 в следующей химической формуле?" };
            Question question1_6 = new Question { Id = Guid.NewGuid().ToString(), TestId = test1.Id, TextQuestion = "Что делает тег &lt;s&gt;?" };
            Question question1_7 = new Question { Id = Guid.NewGuid().ToString(), TestId = test1.Id, TextQuestion = "В чем различие между списками &lt;ol&gt; и &lt;ul&gt;?" };
            Question question1_8 = new Question { Id = Guid.NewGuid().ToString(), TestId = test1.Id, TextQuestion = "Что записывается в атрибут alt тега &lt;img&gt;?" };

            Question question2_1 = new Question { Id = Guid.NewGuid().ToString(), TestId = test2.Id, TextQuestion = "Какой тип значения будет задан переменной $var после выполнения кода $var = '123.45';?" };
            Question question2_2 = new Question { Id = Guid.NewGuid().ToString(), TestId = test2.Id, TextQuestion = "Как правильно создать новый массив?" };
            Question question2_3 = new Question { Id = Guid.NewGuid().ToString(), TestId = test2.Id, TextQuestion = "С помощью какого символа можно склеить две строки в одну?" };
            Question question2_4 = new Question { Id = Guid.NewGuid().ToString(), TestId = test2.Id, TextQuestion = "Какой оператор используется для вывода на экран?" };
            Question question2_5 = new Question { Id = Guid.NewGuid().ToString(), TestId = test2.Id, TextQuestion = "Как присвоить переменной a значение 5?" };
            Question question2_6 = new Question { Id = Guid.NewGuid().ToString(), TestId = test2.Id, TextQuestion = "Что будет в переменной $var после выполнения кода $var = 4 + 8 / 2;?" };
            Question question2_7 = new Question { Id = Guid.NewGuid().ToString(), TestId = test2.Id, TextQuestion = "Можно ли встраивать PHP-код в HTML-код?" };
            Question question2_8 = new Question { Id = Guid.NewGuid().ToString(), TestId = test2.Id, TextQuestion = "Как получить данные POST-запроса?" };

            Question question3_1 = new Question { Id = Guid.NewGuid().ToString(), TestId = test3.Id, TextQuestion = "Как объявить стиль для печати?" };
            Question question3_2 = new Question { Id = Guid.NewGuid().ToString(), TestId = test3.Id, TextQuestion = "Как правильно писать комментарии в CSS файле?" };
            Question question3_3 = new Question { Id = Guid.NewGuid().ToString(), TestId = test3.Id, TextQuestion = "Как правильно задать тег, который будет описывать класс стиля для элемента div?" };
            Question question3_4 = new Question { Id = Guid.NewGuid().ToString(), TestId = test3.Id, TextQuestion = "Какое из этих значений НЕ может быть значением для font-size?" };
            Question question3_5 = new Question { Id = Guid.NewGuid().ToString(), TestId = test3.Id, TextQuestion = "Как задать цвет шрифту?" };
            Question question3_6 = new Question { Id = Guid.NewGuid().ToString(), TestId = test3.Id, TextQuestion = "Какое значение НЕ может быть у border-style?" };
            Question question3_7 = new Question { Id = Guid.NewGuid().ToString(), TestId = test3.Id, TextQuestion = "Какое свойство нужно добавить в тег img, чтобы получить тень внутри картинки?" };
            Question question3_8 = new Question { Id = Guid.NewGuid().ToString(), TestId = test3.Id, TextQuestion = "Какая строка задает изображение для фона и повторяет его по вертикали?" };

            Question question4_1 = new Question { Id = Guid.NewGuid().ToString(), TestId = test4.Id, TextQuestion = "How to correct add padding for a text block?" };
            Question question4_2 = new Question { Id = Guid.NewGuid().ToString(), TestId = test4.Id, TextQuestion = "Which property makes all letters capitalized?" };
            Question question4_3 = new Question { Id = Guid.NewGuid().ToString(), TestId = test4.Id, TextQuestion = "How to hide any element from the page?" };
            Question question4_4 = new Question { Id = Guid.NewGuid().ToString(), TestId = test4.Id, TextQuestion = "How to override the default styles of list items (li elemetns)?" };
            Question question4_5 = new Question { Id = Guid.NewGuid().ToString(), TestId = test4.Id, TextQuestion = "A fixed position element is positioned relative to the viewport, or the browser window itself" };
            Question question4_6 = new Question { Id = Guid.NewGuid().ToString(), TestId = test4.Id, TextQuestion = "How to set the width of a block element to the entire area?" };
            Question question4_7 = new Question { Id = Guid.NewGuid().ToString(), TestId = test4.Id, TextQuestion = "Aligns a parent block to the left, and all other childs flow to the right" };
            Question question4_8 = new Question { Id = Guid.NewGuid().ToString(), TestId = test4.Id, TextQuestion = "Find the syntax error:" };

            Question question5_1 = new Question { Id = Guid.NewGuid().ToString(), TestId = test5.Id, TextQuestion = "Какую функцию выполняет оператор %?" };
            Question question5_2 = new Question { Id = Guid.NewGuid().ToString(), TestId = test5.Id, TextQuestion = "Сколько ключевых слов зарезервировано языком?" };
            Question question5_3 = new Question { Id = Guid.NewGuid().ToString(), TestId = test5.Id, TextQuestion = "Какого модификатора класса НЕ существует?" };
            Question question5_4 = new Question { Id = Guid.NewGuid().ToString(), TestId = test5.Id, TextQuestion = "Какой тип данных не является примитивным?" };
            Question question5_5 = new Question { Id = Guid.NewGuid().ToString(), TestId = test5.Id, TextQuestion = "Какие основные принципы ООП Java?" };
            Question question5_6 = new Question { Id = Guid.NewGuid().ToString(), TestId = test5.Id, TextQuestion = "Как правильно объявить переменную?" };
            Question question5_7 = new Question { Id = Guid.NewGuid().ToString(), TestId = test5.Id, TextQuestion = "Какие из зарезервированных слов не используются?" };
            Question question5_8 = new Question { Id = Guid.NewGuid().ToString(), TestId = test5.Id, TextQuestion = "Присутствует ли в классе Java конструкторы?" };

            Question question6_1 = new Question { Id = Guid.NewGuid().ToString(), TestId = test6.Id, TextQuestion = "Существует ли инкапсуляция в С++?" };
            Question question6_2 = new Question { Id = Guid.NewGuid().ToString(), TestId = test6.Id, TextQuestion = "Существует ли понятие интерфейса в С++?" };
            Question question6_3 = new Question { Id = Guid.NewGuid().ToString(), TestId = test6.Id, TextQuestion = "Существует ли в С++ множественное наследование?" };
            Question question6_4 = new Question { Id = Guid.NewGuid().ToString(), TestId = test6.Id, TextQuestion = "Что нужно подключить для работы с файлами?" };
            Question question6_5 = new Question { Id = Guid.NewGuid().ToString(), TestId = test6.Id, TextQuestion = "Как еще называют логическое отрицание?" };
            Question question6_6 = new Question { Id = Guid.NewGuid().ToString(), TestId = test6.Id, TextQuestion = "Что такое абстрактный метод?" };
            Question question6_7 = new Question { Id = Guid.NewGuid().ToString(), TestId = test6.Id, TextQuestion = "Что означает ключевое слово override?" };
            Question question6_8 = new Question { Id = Guid.NewGuid().ToString(), TestId = test6.Id, TextQuestion = "Что такое конъюнкция?" };


            //HTML test
 Answer answer1_1_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_1.Id, TextAnswer = "&lt;comment&gt; Комментарий &lt;/comment&gt;" };
 Answer answer1_1_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_1.Id, TextAnswer = "/* Комментарий */" };
 Answer answer1_1_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_1.Id, TextAnswer = "&lt;!--Комментарий--&gt;" };

 Answer answer1_2_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_2.Id, TextAnswer = "&lt;a href='link.html' target='_blank'&gt;" };
 Answer answer1_2_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_2.Id, TextAnswer = "&lt;a href='link.html' target='_new'&gt" };
 Answer answer1_2_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_2.Id, TextAnswer = "Никак" };

 Answer answer1_3_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_3.Id, TextAnswer = "title" };
 Answer answer1_3_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_3.Id, TextAnswer = "target" };
 Answer answer1_3_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_3.Id, TextAnswer = "href" };

 Answer answer1_4_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_4.Id, TextAnswer = "Заголовок, не отображаемый на самой странице. Располагается в теге &lt;body&gt;" };
 Answer answer1_4_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_4.Id, TextAnswer = "Заголовок, не отображаемый на самой странице. Располагается в теге &lt;head&gt;" };
 Answer answer1_4_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_4.Id, TextAnswer = "Заголовок, отображаемый на странице, чаще всего в центре сверху. Располагается в теге &lt;head&gt;" };

 Answer answer1_5_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_5.Id, TextAnswer = "&lt;sub&gt;" };
 Answer answer1_5_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_5.Id, TextAnswer = "&lt;small&gt;" };
 Answer answer1_5_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_5.Id, TextAnswer = "&lt;sup&gt;" };

 Answer answer1_6_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_6.Id, TextAnswer = "Открывает новую секцию разметки" };
 Answer answer1_6_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_6.Id, TextAnswer = "Перечеркивает текст" };
 Answer answer1_6_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_6.Id, TextAnswer = "Подчеркивает текст" };

 Answer answer1_7_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_7.Id, TextAnswer = "&lt;ol&gt; - ненумерованный список, а &lt;ul&gt; - нумерованный" };
 Answer answer1_7_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_7.Id, TextAnswer = "&lt;ol&gt; - нумерованный список, а &lt;ul&gt; - ненумерованный" };
 Answer answer1_7_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_7.Id, TextAnswer = " &lt;ol&gt; - вертикальный вывод элементов списка, а &lt;ul&gt; - горизонтальный" };

 Answer answer1_8_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_8.Id, TextAnswer = "Описание изображения" };
 Answer answer1_8_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_8.Id, TextAnswer = "Изменение размера изображения" };
 Answer answer1_8_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question1_8.Id, TextAnswer = "Альтернативная ссылка на изображение" };

 //PHP test
 Answer answer2_1_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_1.Id, TextAnswer = "int" };
 Answer answer2_1_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_1.Id, TextAnswer = "string" };
 Answer answer2_1_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_1.Id, TextAnswer = "float" };

 Answer answer2_2_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_2.Id, TextAnswer = "$array = new array [ ];" };
 Answer answer2_2_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_2.Id, TextAnswer = "$array = array('el', 'el2');" };
 Answer answer2_2_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_2.Id, TextAnswer = "array $array = ['el1'], ['el2'];" };

 Answer answer2_3_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_3.Id, TextAnswer = "" };
 Answer answer2_3_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_3.Id, TextAnswer = "" };
 Answer answer2_3_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_3.Id, TextAnswer = "" };

 Answer answer2_4_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_4.Id, TextAnswer = "" };
 Answer answer2_4_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_4.Id, TextAnswer = "" };
 Answer answer2_4_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_4.Id, TextAnswer = "" };

 Answer answer2_5_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_5.Id, TextAnswer = "" };
 Answer answer2_5_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_5.Id, TextAnswer = "" };
 Answer answer2_5_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_5.Id, TextAnswer = "" };

 Answer answer2_6_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_6.Id, TextAnswer = "" };
 Answer answer2_6_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_6.Id, TextAnswer = "" };
 Answer answer2_6_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_6.Id, TextAnswer = "" };

 Answer answer2_7_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_7.Id, TextAnswer = "" };
 Answer answer2_7_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_7.Id, TextAnswer = "" };
 Answer answer2_7_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_7.Id, TextAnswer = "" };

 Answer answer2_8_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_8.Id, TextAnswer = "" };
 Answer answer2_8_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_8.Id, TextAnswer = "" };
 Answer answer2_8_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question2_8.Id, TextAnswer = "" };

 //Web forms test
 Answer answer3_1_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_1.Id, TextAnswer = "" };
 Answer answer3_1_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_1.Id, TextAnswer = "" };
 Answer answer3_1_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_1.Id, TextAnswer = "" };

 Answer answer3_2_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_2.Id, TextAnswer = "" };
 Answer answer3_2_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_2.Id, TextAnswer = "" };
 Answer answer3_2_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_2.Id, TextAnswer = "" };

 Answer answer3_3_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_3.Id, TextAnswer = "" };
 Answer answer3_3_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_3.Id, TextAnswer = "" };
 Answer answer3_3_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_3.Id, TextAnswer = "" };

 Answer answer3_4_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_4.Id, TextAnswer = "" };
 Answer answer3_4_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_4.Id, TextAnswer = "" };
 Answer answer3_4_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_4.Id, TextAnswer = "" };

 Answer answer3_5_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_5.Id, TextAnswer = "" };
 Answer answer3_5_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_5.Id, TextAnswer = "" };
 Answer answer3_5_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_5.Id, TextAnswer = "" };

 Answer answer3_6_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_6.Id, TextAnswer = "" };
 Answer answer3_6_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_6.Id, TextAnswer = "" };
 Answer answer3_6_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_6.Id, TextAnswer = "" };

 Answer answer3_7_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_7.Id, TextAnswer = "" };
 Answer answer3_7_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_7.Id, TextAnswer = "" };
 Answer answer3_7_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_7.Id, TextAnswer = "" };

 Answer answer3_8_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_8.Id, TextAnswer = "" };
 Answer answer3_8_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_8.Id, TextAnswer = "" };
 Answer answer3_8_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question3_8.Id, TextAnswer = "" };

 //CSS test
 Answer answer4_1_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_1.Id, TextAnswer = "" };
 Answer answer4_1_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_1.Id, TextAnswer = "" };
 Answer answer4_1_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_1.Id, TextAnswer = "" };

 Answer answer4_2_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_2.Id, TextAnswer = "" };
 Answer answer4_2_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_2.Id, TextAnswer = "" };
 Answer answer4_2_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_2.Id, TextAnswer = "" };

 Answer answer4_3_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_3.Id, TextAnswer = "" };
 Answer answer4_3_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_3.Id, TextAnswer = "" };
 Answer answer4_3_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_3.Id, TextAnswer = "" };

 Answer answer4_4_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_4.Id, TextAnswer = "" };
 Answer answer4_4_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_4.Id, TextAnswer = "" };
 Answer answer4_4_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_4.Id, TextAnswer = "" };

 Answer answer4_5_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_5.Id, TextAnswer = "" };
 Answer answer4_5_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_5.Id, TextAnswer = "" };
 Answer answer4_5_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_5.Id, TextAnswer = "" };

 Answer answer4_6_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_6.Id, TextAnswer = "" };
 Answer answer4_6_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_6.Id, TextAnswer = "" };
 Answer answer4_6_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_6.Id, TextAnswer = "" };

 Answer answer4_7_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_7.Id, TextAnswer = "" };
 Answer answer4_7_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_7.Id, TextAnswer = "" };
 Answer answer4_7_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_7.Id, TextAnswer = "" };

 Answer answer4_8_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_8.Id, TextAnswer = "" };
 Answer answer4_8_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_8.Id, TextAnswer = "" };
 Answer answer4_8_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question4_8.Id, TextAnswer = "" };

 //Java test
 Answer answer5_1_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_1.Id, TextAnswer = "" };
 Answer answer5_1_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_1.Id, TextAnswer = "" };
 Answer answer5_1_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_1.Id, TextAnswer = "" };

 Answer answer5_2_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_2.Id, TextAnswer = "" };
 Answer answer5_2_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_2.Id, TextAnswer = "" };
 Answer answer5_2_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_2.Id, TextAnswer = "" };

 Answer answer5_3_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_3.Id, TextAnswer = "" };
 Answer answer5_3_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_3.Id, TextAnswer = "" };
 Answer answer5_3_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_3.Id, TextAnswer = "" };

 Answer answer5_4_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_4.Id, TextAnswer = "" };
 Answer answer5_4_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_4.Id, TextAnswer = "" };
 Answer answer5_4_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_4.Id, TextAnswer = "" };

 Answer answer5_5_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_5.Id, TextAnswer = "" };
 Answer answer5_5_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_5.Id, TextAnswer = "" };
 Answer answer5_5_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_5.Id, TextAnswer = "" };

 Answer answer5_6_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_6.Id, TextAnswer = "" };
 Answer answer5_6_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_6.Id, TextAnswer = "" };
 Answer answer5_6_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_6.Id, TextAnswer = "" };

 Answer answer5_7_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_7.Id, TextAnswer = "" };
 Answer answer5_7_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_7.Id, TextAnswer = "" };
 Answer answer5_7_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_7.Id, TextAnswer = "" };

 Answer answer5_8_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_8.Id, TextAnswer = "" };
 Answer answer5_8_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_8.Id, TextAnswer = "" };
 Answer answer5_8_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question5_8.Id, TextAnswer = "" };

 //C++ test
 Answer answer6_1_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_1.Id, TextAnswer = "" };
 Answer answer6_1_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_1.Id, TextAnswer = "" };
 Answer answer6_1_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_1.Id, TextAnswer = "" };

 Answer answer6_2_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_2.Id, TextAnswer = "" };
 Answer answer6_2_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_2.Id, TextAnswer = "" };
 Answer answer6_2_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_2.Id, TextAnswer = "" };

 Answer answer6_3_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_3.Id, TextAnswer = "" };
 Answer answer6_3_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_3.Id, TextAnswer = "" };
 Answer answer6_3_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_3.Id, TextAnswer = "" };

 Answer answer6_4_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_4.Id, TextAnswer = "" };
 Answer answer6_4_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_4.Id, TextAnswer = "" };
 Answer answer6_4_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_4.Id, TextAnswer = "" };

 Answer answer6_5_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_5.Id, TextAnswer = "" };
 Answer answer6_5_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_5.Id, TextAnswer = "" };
 Answer answer6_5_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_5.Id, TextAnswer = "" };

 Answer answer6_6_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_6.Id, TextAnswer = "" };
 Answer answer6_6_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_6.Id, TextAnswer = "" };
 Answer answer6_6_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_6.Id, TextAnswer = "" };

 Answer answer6_7_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_7.Id, TextAnswer = "" };
 Answer answer6_7_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_7.Id, TextAnswer = "" };
 Answer answer6_7_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_7.Id, TextAnswer = "" };

 Answer answer6_8_1 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_8.Id, TextAnswer = "" };
 Answer answer6_8_2 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_8.Id, TextAnswer = "" };
 Answer answer6_8_3 = new Answer { Id = Guid.NewGuid().ToString(), QuestionId = question6_8.Id, TextAnswer = "" };





 question1_1.CorrectAnswerId = answer1_1_3.Id;
 question1_2.CorrectAnswerId = answer1_2_1.Id;
 question1_3.CorrectAnswerId = answer1_3_3.Id;
 question1_4.CorrectAnswerId = answer1_4_2.Id;
 question1_5.CorrectAnswerId = answer1_5_1.Id;
 question1_6.CorrectAnswerId = answer1_6_2.Id;
 question1_7.CorrectAnswerId = answer1_7_2.Id;
 question1_8.CorrectAnswerId = answer1_8_1.Id;

 question2_1.CorrectAnswerId = answer2_1_2.Id;
 question2_2.CorrectAnswerId = answer2_2_2.Id;
 question2_3.CorrectAnswerId = answer2_3_1.Id;
 question2_4.CorrectAnswerId = answer2_4_3.Id;
 question2_5.CorrectAnswerId = answer2_5_2.Id;
 question2_6.CorrectAnswerId = answer2_6_2.Id;
 question2_7.CorrectAnswerId = answer2_7_1.Id;
 question2_8.CorrectAnswerId = answer2_8_2.Id;

 question3_1.CorrectAnswerId = answer3_1_1.Id;
 question3_2.CorrectAnswerId = answer3_2_1.Id;
 question3_3.CorrectAnswerId = answer3_3_3.Id;
 question3_4.CorrectAnswerId = answer3_4_2.Id;
 question3_5.CorrectAnswerId = answer3_5_1.Id;
 question3_6.CorrectAnswerId = answer3_6_2.Id;
 question3_7.CorrectAnswerId = answer3_7_2.Id;
 question3_8.CorrectAnswerId = answer3_8_3.Id;

 question4_1.CorrectAnswerId= answer4_1_1.Id;
question4_2.CorrectAnswerId = answer4_2_3.Id;
 question4_3.CorrectAnswerId = answer4_3_2.Id;
 question4_4.CorrectAnswerId = answer4_4_2.Id;
 question4_5.CorrectAnswerId = answer4_5_3.Id;
 question4_6.CorrectAnswerId = answer4_6_2.Id;
 question4_7.CorrectAnswerId = answer4_7_1.Id;
 question4_8.CorrectAnswerId = answer4_8_1.Id;

 question5_1.CorrectAnswerId = answer5_1_1.Id;
 question5_2.CorrectAnswerId = answer5_2_2.Id;
 question5_3.CorrectAnswerId = answer5_3_3.Id;
 question5_4.CorrectAnswerId = answer5_4_2.Id;
 question5_5.CorrectAnswerId = answer5_5_2.Id;
 question5_6.CorrectAnswerId = answer5_6_1.Id;
 question5_7.CorrectAnswerId = answer5_7_2.Id;
 question5_8.CorrectAnswerId = answer5_8_1.Id;

 question6_1.CorrectAnswerId = answer6_1_2.Id;
 question6_2.CorrectAnswerId= answer6_2_1.Id;
 question6_3.CorrectAnswerId= answer6_3_2.Id;
 question6_4.CorrectAnswerId = answer6_4_1.Id;
 question6_5.CorrectAnswerId = answer6_5_3.Id;
 question6_6.CorrectAnswerId = answer6_6_2.Id;
 question6_7.CorrectAnswerId = answer6_7_1.Id;
 question6_8.CorrectAnswerId = answer6_8_2.Id;


















































 modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
 modelBuilder.Entity<User>().HasData(new User[] { adminUser, simpleUser1, simpleUser2 });
 modelBuilder.Entity<Test>().HasData(new Test[] { test1, test2, test3, test4, test5, test6 });

 modelBuilder.Entity<UserTest>().HasData(new UserTest[] { userTests1, userTests2, userTests3, userTests4, userTests5, userTests6, userTests7});

 modelBuilder.Entity<Question>().HasData(new Question[] { 
     question1_1, question1_2, question1_3, question1_4, question1_5, question1_6, question1_7, question1_8,
     question2_1, question2_2, question2_3, question2_4, question2_5, question2_6, question2_7, question2_8,
     question3_1, question3_2, question3_3, question3_4, question3_5, question3_6, question3_7, question3_8,
     question4_1, question4_2, question4_3, question4_4, question4_5, question4_6, question4_7, question4_8,
     question5_1, question5_2, question5_3, question5_4, question5_5, question5_6, question5_7, question5_8,
     question6_1, question6_2, question6_3, question6_4, question6_5, question6_6, question6_7, question6_8});


 modelBuilder.Entity<Answer>().HasData(new Answer [] { 
     answer1_1_1, answer1_1_2,  answer1_1_3,
     answer1_2_1, answer1_2_2,  answer1_2_3,
     answer1_3_1, answer1_3_2,  answer1_3_3,
     answer1_4_1, answer1_4_2,  answer1_4_3,
     answer1_5_1, answer1_5_2,  answer1_5_3,
     answer1_6_1, answer1_6_2,  answer1_6_3,
     answer1_7_1, answer1_7_2,  answer1_7_3,
     answer1_8_1, answer1_8_2,  answer1_8_3,

     answer2_1_1, answer2_1_2,  answer2_1_3,
     answer2_2_1, answer2_2_2,  answer2_2_3,
     answer2_3_1, answer2_3_2,  answer2_3_3,
     answer2_4_1, answer2_4_2,  answer2_4_3,
     answer2_5_1, answer2_5_2,  answer2_5_3,
     answer2_6_1, answer2_6_2,  answer2_6_3,
     answer2_7_1, answer2_7_2,  answer2_7_3,
     answer2_8_1, answer2_8_2,  answer2_8_3,

      answer3_1_1, answer3_1_2,  answer3_1_3,
     answer3_2_1, answer3_2_2,  answer3_2_3,
     answer3_3_1, answer3_3_2,  answer3_3_3,
     answer3_4_1, answer3_4_2,  answer3_4_3,
     answer3_5_1, answer3_5_2,  answer3_5_3,
     answer3_6_1, answer3_6_2,  answer3_6_3,
     answer3_7_1, answer3_7_2,  answer3_7_3,
     answer3_8_1, answer3_8_2,  answer3_8_3,

      answer4_1_1, answer4_1_2,  answer4_1_3,
     answer4_2_1, answer4_2_2,  answer4_2_3,
     answer4_3_1, answer4_3_2,  answer4_3_3,
     answer4_4_1, answer4_4_2,  answer4_4_3,
     answer4_5_1, answer4_5_2,  answer4_5_3,
     answer4_6_1, answer4_6_2,  answer4_6_3,
     answer4_7_1, answer4_7_2,  answer4_7_3,
     answer4_8_1, answer4_8_2,  answer4_8_3,

      answer5_1_1, answer5_1_2,  answer5_1_3,
     answer5_2_1, answer5_2_2,  answer5_2_3,
     answer5_3_1, answer5_3_2,  answer5_3_3,
     answer5_4_1, answer5_4_2,  answer5_4_3,
     answer5_5_1, answer5_5_2,   answer5_5_3,
     answer5_6_1, answer5_6_2,  answer5_6_3,
     answer5_7_1, answer5_7_2,  answer5_7_3,
     answer5_8_1, answer5_8_2,  answer5_8_3,

      answer6_1_1, answer6_1_2,  answer6_1_3,
     answer6_2_1, answer6_2_2,  answer6_2_3,
     answer6_3_1, answer6_3_2,  answer6_3_3,
     answer6_4_1, answer6_4_2,  answer6_4_3,
     answer6_5_1, answer6_5_2,  answer6_5_3,
     answer6_6_1, answer6_6_2,  answer6_6_3,
     answer6_7_1, answer6_7_2,  answer6_7_3,
     answer6_8_1, answer6_8_2,  answer6_8_3


 });

 base.OnModelCreating(modelBuilder);
}
}
}
