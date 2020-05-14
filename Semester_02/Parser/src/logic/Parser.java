package java;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.IOException;
import java.util.ArrayList;

public class Parser  {
    //класс, определенный в библиотеке jsoup, является результатом парсинга DOM-дерева
    Document document;

    public void parseHTML(String html, boolean isURL) throws IOException {
        if (isURL) {
            this.document = Jsoup.connect("http://jsoup.org").get();
        } else {
            this.document = Jsoup.parse(html);
        }
    }

    public String checkTitle() {
        String result ="";

        Boolean isExisting;
        Boolean isUnique;
        Boolean isLengthOk;

        Elements pageTitle = this.document.select("title");

        //проверка, что title существует
        if (pageTitle.size() == 0) {
            isExisting = false;
            result = "Элемента title нет на странице";
        } else {
            isExisting = true;

            //проверка того, что это единственный элемент на странице
            if (pageTitle.size() == 1) {
                isUnique = true;
                result += "\nЭлемент title уникален на странице - ОК";
            } else {
                isUnique = false;
                result += "\nЭлемент title не уникален на странице";
            }

            //проверка содержимого title
            String titleValue = pageTitle.get(0).text();
            result += "Содержимое title: " + titleValue;
            if (titleValue.length() <= 60) {
                isLengthOk = true;
                result += "\nДлина title " + titleValue.length() + " символов - ОК";
            } else if (titleValue.length() == 0) {
                isLengthOk = false;
                result += "\ntitle не содержит текста";
            } else {
                isLengthOk = false;
                result += "\nДлина title превышает 60 символов. " +
                        "Постарайтесь уместить наиболее важную информацию в 60 символов";
            }

            //проверка по ключевым словам TODO
        }

        System.out.println(result); //убрать TODO
        return result;
    }
}

//а)	Ввести анализируемой адрес веб-страницы;
//        б)	Выбрать файл с кодом веб-страницы в формате .html или .txt;
//        в)	Выбрать параметры анализа:
//        1)	Анализируемые теги / атрибуты;
//        2)	Анализ длины содержимого тегов;
//        3)	Анализ по ключевым словам.
//        г)	Ввести ключевые слова;
//        д)	Сформировать отчет в формате .txt.
