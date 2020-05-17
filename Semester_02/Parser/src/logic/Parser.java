package logic;

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
            this.document = Jsoup.connect(html).get();
        } else {
            this.document = Jsoup.parse(html);
        }
    }

    public String checkTitle(String ... keyWords) {
        String result ="";

        Boolean isExisting = false;
        Boolean isUnique = false;
        Boolean isLengthOk = false;
        Boolean isIncludeKeys = false;

        Elements pageTitles = this.document.select("title");

        //проверка, что title существует
        if (pageTitles.size() == 0) {
            isExisting = false;
            result = "Элемента title нет на странице";
        } else {
            isExisting = true;

            //проверка того, что это единственный элемент на странице
            if (pageTitles.size() == 1) {
                isUnique = true;
                result += "\nЭлемент title уникален на странице - ОК\n";
            } else {
                isUnique = false;
                result += "\nЭлемент title не уникален на странице";
            }

            //проверка длины содержимого title
            Element title = pageTitles.get(0);
            String titleValue = title.text();
            result += "Содержимое title:\n\t" + titleValue;
            result += checkLength(title,0, 60, isLengthOk);

            //проверка вхождения ключевых слов в title
            result += getIncludedKeys(title, keyWords, isIncludeKeys);
        }

        System.out.println("\ntitle:" + result); //убрать TODO
        return result;
    }

    //проверка заголовка первого уровня h1
    public String checkHeaders(String ... keyWords) {
        String result = "";

        Boolean isExisting = false;
        Boolean isUnique = false;
        Boolean isLengthOk = false;
        Boolean isOrderOk = true;
        Boolean isIncludeKeys = false;

        //выбор всех заголовков первого уровня h1 на странице
        Elements pageHeaders1 = this.document.select("h1");
        //проверка, что h1существует
        if (pageHeaders1.size() == 0) {
            isExisting = false;
            result = "На странице нет заголовка первого уровня h1";
        } else {
            isExisting = true;

            //проверка того, что h1 уникален на странице
            if (pageHeaders1.size() == 1) {
                isUnique = true;
                result += "\nЗаголовок первого уровня h1 уникален на странице - ОК\n";
            } else {
                isUnique = false;
                result += "\nЗаголовок первого уровня h1 не уникален на странице - " +
                        "этот заголовок должен быть единственным на странице";
            }

            //сохранение содержимого заголовка h1
            Element header1 = pageHeaders1.get(0);
            String header1Value = header1.text();
            result += "\nСодержимое заголовка h1:\n\t" + header1Value;

            //проверка длины содержимого h1
            result += checkLength(header1, 0, 70, isLengthOk);

            //проверка вхождения ключевых слов в title
            result += getIncludedKeys(header1, keyWords, isIncludeKeys);
        }

        //проверка порядка следования заголовков
        Element body = this.document.selectFirst("body");
        String headersOrder = getHeaders(body);

        //проверка того, что h1 - первый заголовок
        if (isUnique & headersOrder.charAt(0) == '1') {
            isOrderOk = true;
            result += "\nh1 - первый заголовок на странице - ОК\n";
        } else if (isExisting){
            isOrderOk = false;
            result += "\nh1 не является первым заголовком на странице";
        }

        //проверка порядка появления заголовков h2-h6
        String[] headersNumbers = headersOrder.split(" ");
        int defaultValue = headersNumbers.length;
        int h2FirstIndex = defaultValue;
        int h3FirstIndex = defaultValue;
        int h4FirstIndex = defaultValue;
        int h5FirstIndex = defaultValue;
        int h6FirstIndex = defaultValue;

        //нахождение первого появления заголовка каждого уровня
        for (int i = 0; i < headersNumbers.length; i++) {
            switch (Integer.parseInt(headersNumbers[i])) {
                case 2:
                    if (h2FirstIndex == defaultValue) {
                        h2FirstIndex = i;
                    }
                    break;
                case 3:
                    if (h3FirstIndex == defaultValue) {
                        h3FirstIndex = i;
                    }
                    break;
                case 4:
                    if (h4FirstIndex == defaultValue) {
                        h4FirstIndex = i;
                    }
                    break;
                case 5:
                    if (h5FirstIndex == defaultValue) {
                        h5FirstIndex = i;
                    }
                    break;
                case 6:
                    if (h6FirstIndex == defaultValue) {
                        h6FirstIndex = i;
                    }
                    break;
                default:
                    break;
            }
        }

        //все заголовки должны появляться в первый раз по порядку
        String headersProblem = "";
        if (h2FirstIndex > h3FirstIndex) {
            if (h2FirstIndex == defaultValue) {
                headersProblem += "\n\tЗаголовок h2 пропущен";
            } else {
                headersProblem += "\n\tЗаголовок h2 появляется позже заголовка h3";
            }
            isOrderOk = false;

        } else if (h3FirstIndex > h4FirstIndex) {
            if (h3FirstIndex == defaultValue) {
                headersProblem += "\n\tЗаголовок h3 пропущен";
            } else {
                headersProblem += "\n\tЗаголовок h3 появляется позже заголовка h4";
            }
            isOrderOk = false;

        } else if (h4FirstIndex > h5FirstIndex) {
            if (h4FirstIndex == defaultValue) {
                headersProblem += "\n\tЗаголовок h4 пропущен";
            } else {
                headersProblem += "\n\tЗаголовок h4 появляется позже заголовка h5";
            }
            isOrderOk = false;

        } else if (h5FirstIndex > h6FirstIndex) {
            if (h5FirstIndex == defaultValue) {
                headersProblem += "\n\tЗаголовок h5 пропущен";
            } else {
                headersProblem += "\n\tЗаголовок h5 появляется позже заголовка h6";
            }
            isOrderOk = false;
        }

        if (isOrderOk) {
            result += "\nЗаголовки h2-h6 появляются в правильном порядке\n";
        } else {
            result += "\nНарушен порядок следования заголовков h2-h6: " + headersProblem;
        }

        System.out.println(result);
        return result;
    }


    //проверка порядка следования заголовков
    //рекурсивный обход потомков элемента
    //возвращает строку с последовательностью уровней заголовков через пробел
    public String getHeaders(Element elem) {
        String result = "";
        switch(elem.normalName()) {
            case "h1":
                result += "1 ";
                break;
            case "h2":
                result += "2 ";
                break;
            case "h3":
                result += "3 ";
                break;
            case "h4":
                result += "4 ";
                break;
            case "h5":
                result += "5 ";
                break;
            case "h6":
                result += "6 ";
                break;
            default:
                break;
        }

        if (elem.childrenSize() != 0) {
            for (Element child : elem.children()) {
                result += getHeaders(child);
            }
        }
        return result;
    }


    //проверка вхождения ключевых слов в текст элемента
    public String getIncludedKeys(Element element, String[] keys, Boolean isIncludeKeys) {
        String result = element.normalName() + " не содержит ключевых слов\n";
        isIncludeKeys = false;
        String[] elementWords = element.text().split(" ");
        int keysInElement = 0;

        for (String word : elementWords) {
            for (String key : keys) {
                if (WordsHandler.handle(word).toLowerCase().equals(key.toLowerCase())) {
                    isIncludeKeys = true;
                    keysInElement ++;
                }
            }
        }
        if (isIncludeKeys) {
            result = element.normalName() + " содержит ключевые слова (количество слов: " + keysInElement + ") - ОК\n";
        }
        return result;
    }

    //проверка длины содержимого элемента
    public String checkLength(Element element, int minLength, int maxLength, Boolean isLengthOk) {
        String elementValue = element.text();
        //по умолчанию длина элемента меньше нормы
        isLengthOk = false;
        String result = "\nДлина " + element.normalName() + " составляет " + elementValue.length() +
                " символов - это меньше рекомендуемой длины\n";

        //проверка длины
        if (elementValue.length() >= minLength & elementValue.length() <= maxLength) {
            isLengthOk = true;
            result = "\nДлина " + element.normalName() + " составляет "+ elementValue.length() + " символов - ОК\n";
        } else if (elementValue.length() > maxLength ) {
            isLengthOk = false;
            result = "\nДлина " + element.normalName() + " составляет " + elementValue.length() +
                    " и превышает рекомендуемую длину в" + maxLength +" символов";
        }
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
