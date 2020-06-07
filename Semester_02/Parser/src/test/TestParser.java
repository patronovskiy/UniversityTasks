package test;

import logic.Parser;
import org.jsoup.nodes.Document;
import org.junit.Assert;
import org.junit.Test;

import java.io.IOException;

//Тесты
public class TestParser {

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
            String rightResult1 = "ТЕГ <title>:" +
                                    "\n\tЭлемент title уникален на странице - ОК"
                                    + "\n\tСодержимое title:\n\t\tПривет, мир!!!!!"
                                    + "\n\tДлина title составляет 16 символов - ОК"
                                    + "\n\ttitle содержит ключевые слова (количество слов: 1) - ОК\n";
            Assert.assertEquals("Метод проверки title не прошел тесты", rightResult1, result1);

            //случай 2 - элемент title не уникален
            parser.parseHTML(debugHTML2, false);
            String result2 = parser.checkTitle();
            String rightResult2 = "ТЕГ <title>:" +
                                "\n\tЭлемент title не уникален на странице - несоответсвие\n";

        } catch (IOException e){
            System.out.println("Ошибка ввода-вывода");
        }

    }

}