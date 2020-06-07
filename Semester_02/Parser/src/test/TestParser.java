package test;

import logic.Parser;
import org.jsoup.nodes.Document;
import org.junit.Assert;
import org.junit.Test;

import java.io.IOException;

//Тесты
public class TestParser extends Parser {

    //HTML-код для тестирования

        String debugHTML1 = "  <!DOCTYPE html>\n" +
                "  <html lang=\"ru\">\n" +
                "    <head>\n" +
                "      <meta charset=\"utf-8\">\n" +
                "<meta name=\"description\" content=\"ааа мир\"" +
                "      <title>Привет, мир!!!!!</title>\n" +
                "    </head>\n" +
                "    <body>\n" +
                "      <h1>Привет, мир!</h1>\n" +
                "      <p>Это веб-страница.</p>\n" +
                "<div><h2></h2><h4></h4></div>"+ "<h3></h3>" +
                "<img alt=\"alt\">" +
                "    </body>\n" +
                "  </html>\n";


    //Тестирование главного метода в парсере
    @Test
    public void testStart() {
    //todo
    }


    //тестирование метода, проверяющего тег <title>
    @Test
    public void testCheckTitle() {
        Parser parser = new Parser();
        parser.setKeys("Vbh", "МИР", "title");
        String debugHTML1 = "  <!DOCTYPE html>\n" +
                "  <html lang=\"ru\">\n" +
                "    <head>\n" +
                "      <title>Привет, мир!!!!!</title>\n" +
                "    </head>\n" +
                "    <body>\n" +
                "      <h1>Привет, мир!</h1>\n" +
                "    </body>\n" +
                "  </html>\n";

        String debugHTML2 = "  <!DOCTYPE html>\n" +
                "  <html lang=\"ru\">\n" +
                "    <head>\n" +
                "      <title>Привет, мир!!!!!</title>\n" +
                "      <title>VBH мир</title>\n" +
                "    </head>\n" +
                "    <body>\n" +
                "      <h1>Привет, мир!</h1>\n" +
                "    </body>\n" +
                "  </html>\n";

        try {
            //случай 1 - все ОК
            parser.parseHTML(debugHTML1, false);
            String result1 = parser.checkTitle();
            String rightResult1 = "\nЭлемент title уникален на странице - ОК"
                                    + "Содержимое title:\n\tПривет, мир!!!!!"
                                    + "\nДлина title составляет 16 символов - ОК"
                                    + "\ntitle содержит ключевые слова (количество слов: 1) - ОК";
            Assert.assertEquals("Метод проверки title не прошел тесты", rightResult1, result1);

            //случай 2 - элемент title не уникален
            parser.parseHTML(debugHTML2, false);
            String result2 = parser.checkTitle();
            String rightResult2 = "\nЭлемент title не уникален на странице - несоответсвие";

        } catch (IOException e){
            System.out.println("Ошибка ввода-вывода");
        }

    }




}