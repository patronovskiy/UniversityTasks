package logic;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;
import org.junit.Assert;
import org.junit.Test;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

public class Parser  {
    //класс, определенный в библиотеке jsoup, является результатом парсинга DOM-дерева
    Document document;

    //ключевые слова
    String[] keyWords = null;

    //флаги состяния тегов
    //title
    Boolean isTitleExisting = false;
    Boolean isTitleUnique = false;
    Boolean isTitleLengthOk = false;
    Boolean isTitleIncludeKeys = false;

    //h1
    Boolean isHeader1Existing = false;
    Boolean isHeader1Unique = false;
    Boolean isHeader1LengthOk = false;
    Boolean isHeader1IncludeKeys = false;

    //h2-h6
    Boolean isHeadersOrderOk = true;

    //теги форматирования
    Boolean isFormattingTagsUsed = false;

    //<meta name="description">
    Boolean isMetsDescriptionUnique = false;
    Boolean isDescriptionLengthOk = false;
    Boolean getIsDescriptionIncludeKeys = false;

    //<img alt="альтернативный текст">
    Boolean areImagesExist = false;
    Boolean areAllImagesAlted = false;


    public void setKeys(String ... keys) {
        if (keys.length > 0) {
            this.keyWords = keys;
        }
    }

    public String[] getKeys(String string) {
        String[] keys = string.split(" ");
        for (int i = 0; i < keys.length; i++) {
            keys[i] = WordsHandler.handle(keys[i]);
        }
        return keys;
    }

    public void start() {
        checkTitle();
        checkHeaders();
        checkFormattingTags();
        checkDescription();
        checkImgAlts();
    }

    public void parseHTML(String html, boolean isURL) throws IOException {
        if (isURL) {
            this.document = Jsoup.connect(html).get();
        } else {
            this.document = Jsoup.parse(html);
        }
    }

    public String checkTitle() {
        String result ="";

        Elements pageTitles = this.document.select("title");

        //проверка, что title существует
        if (pageTitles.size() == 0) {
            isTitleExisting = false;
            result = "\nЭлемента title нет на странице";
        } else {
            isTitleExisting = true;

            //проверка того, что это единственный элемент на странице
            if (pageTitles.size() == 1) {
                isTitleUnique = true;
                result += "\nЭлемент title уникален на странице - ОК";
            } else {
                isTitleUnique = false;
                result += "\nЭлемент title не уникален на странице - несоответсвие";
                return result;
            }

            //проверка длины содержимого title
            Element title = pageTitles.get(0);
            String titleValue = title.text();
            result += "Содержимое title:\n\t" + titleValue;
            result += checkLength(title,0, 60, isTitleLengthOk);

            //проверка вхождения ключевых слов в title
            if (keyWords != null) {
                result += getIncludedKeys(title, isTitleIncludeKeys);
            }
        }

        System.out.println("\ntitle:" + result); //убрать TODO
        return result;
    }

    //проверка заголовка первого уровня h1
    public String checkHeaders() {
        String result = "";

        //выбор всех заголовков первого уровня h1 на странице
        Elements pageHeaders1 = this.document.select("h1");
        //проверка, что h1существует
        if (pageHeaders1.size() == 0) {
            isHeader1Existing = false;
            result = "На странице нет заголовка первого уровня h1";
        } else {
            isHeader1Existing = true;

            //проверка того, что h1 уникален на странице
            if (pageHeaders1.size() == 1) {
                isHeader1Unique = true;
                result += "\nЗаголовок первого уровня h1 уникален на странице - ОК\n";
            } else {
                isHeader1Unique = false;
                result += "\nЗаголовок первого уровня h1 не уникален на странице - " +
                        "этот заголовок должен быть единственным на странице";
            }

            //сохранение содержимого заголовка h1
            Element header1 = pageHeaders1.get(0);
            String header1Value = header1.text();
            result += "\nСодержимое заголовка h1:\n\t" + header1Value;

            //проверка длины содержимого h1
            result += checkLength(header1, 0, 70, isHeader1LengthOk);

            //проверка вхождения ключевых слов в title
            if (keyWords != null) {
                result += getIncludedKeys(header1, isHeader1IncludeKeys);
            }
        }

        //проверка порядка следования заголовков
        Element body = this.document.selectFirst("body");
        String headersOrder = getHeaders(body);

        //проверка того, что h1 - первый заголовок
        if (isHeader1Unique & headersOrder.charAt(0) == '1') {
            isHeadersOrderOk = true;
            result += "\nh1 - первый заголовок на странице - ОК\n";
        } else if (isHeader1Existing){
            isHeadersOrderOk = false;
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
            isHeadersOrderOk = false;

        } else if (h3FirstIndex > h4FirstIndex) {
            if (h3FirstIndex == defaultValue) {
                headersProblem += "\n\tЗаголовок h3 пропущен";
            } else {
                headersProblem += "\n\tЗаголовок h3 появляется позже заголовка h4";
            }
            isHeadersOrderOk = false;

        } else if (h4FirstIndex > h5FirstIndex) {
            if (h4FirstIndex == defaultValue) {
                headersProblem += "\n\tЗаголовок h4 пропущен";
            } else {
                headersProblem += "\n\tЗаголовок h4 появляется позже заголовка h5";
            }
            isHeadersOrderOk = false;

        } else if (h5FirstIndex > h6FirstIndex) {
            if (h5FirstIndex == defaultValue) {
                headersProblem += "\n\tЗаголовок h5 пропущен";
            } else {
                headersProblem += "\n\tЗаголовок h5 появляется позже заголовка h6";
            }
            isHeadersOrderOk = false;
        }

        if (isHeadersOrderOk) {
            result += "\nЗаголовки h2-h6 появляются в правильном порядке\n";
        } else {
            result += "\nНарушен порядок следования заголовков h2-h6: " + headersProblem;
        }

        System.out.println(result);
        return result;
    }

    //проверка наличия тегов форматирования
    public String checkFormattingTags() {
        //по умолчанию тегов форматирования на странице нет
        String result = "Страница не содержит тегов форматирования. " +
                "Рекомендуется использовать теги форматирования, например: " +
                "<p>...</p>,\n" +
                "<ul>...</ul>,\n" +
                "<ol>...</ol>,\n" +
                "<strong>…</strong>,\n" +
                "<em>…</em>,\n" +
                "<blockquote> </blockquote>\n";
        String formattingTags = "";

        //проверка наличия каждого тега (искать тег до первого вхождения)
        if (this.document.selectFirst("p") != null) {
            formattingTags += "<p></p>, ";
            isFormattingTagsUsed = true;
        }

        if (this.document.selectFirst("ul") != null) {
            formattingTags += "<ul></ul>, ";
            isFormattingTagsUsed = true;
        }

        if (this.document.selectFirst("ol") != null) {
            formattingTags += "<ol></ol>, ";
            isFormattingTagsUsed = true;
        }

        if (this.document.selectFirst("strong") != null) {
            formattingTags += "<strong></strong>, ";
            isFormattingTagsUsed = true;
        }

        if (this.document.selectFirst("em") != null) {
            formattingTags += "<em></em>, ";
            isFormattingTagsUsed = true;
        }

        if (this.document.selectFirst("blockquote") != null) {
            formattingTags += "<em></em>, ";
            isFormattingTagsUsed = true;
        }

        if (isFormattingTagsUsed) {
            //убрать последнюю запятую
            formattingTags = formattingTags.substring(0, formattingTags.length()-2);
            result = "Используются теги форматирования: \n\t" + formattingTags;
        }

        System.out.println(result);
        return result;
    }

    //проверка тега <meta name="description">
    public String checkDescription() {
        //по умолчанию описания нет
        String result = "Страница не содержит описания в мета-теге <meta name=\"description\">." +
                "\nРекомендуется добавить тег <meta name=\"description\" content=\"описание в 70-200 символов\">";

        Elements elementsWithNameDescription = this.document.getElementsByAttributeValue("name", "description");
        int metaDescriptions = 0;
        for (Element element : elementsWithNameDescription) {
            if (element.normalName().equals("meta")) {
                metaDescriptions ++;
            }
        }
        if (metaDescriptions == 1) {
            result = "\nСтраница содержит мета-тег <meta name=\"description\" content=\"\">, " +
                    "\nно не содержит описания в атрибуте content";

            Element metaDescription = elementsWithNameDescription.first();
            //извлекаем текст описания
            String description = metaDescription.attributes().get("content");
            if (description.length() > 0) {
                result = "\nСтраница содержит описание в мета-теге <meta name=\"description\" content=\"описание\"> - OK";
                result += "\nСодержание description:\n\t" + description;
                result += checkLength(description, "description", 70, 200, isDescriptionLengthOk);
                if (keyWords != null) {
                    result += getIncludedKeys(description, "description", getIsDescriptionIncludeKeys);
                }
            }

        } else if (metaDescriptions > 1) {
            result = "\nСтраница содержит более 1 мета-тега <meta name=\"description\">." +
                    "Этот тег должен быть единственным на странице.";
        }
        System.out.println(result);
        return result;
    }

    //проверка наличия атрибута alt  тегов изображений img
    public String checkImgAlts() {
        areAllImagesAlted = false;
        String result = "На странице нет изображений в тегах img";

        Elements images = this.document.select("img");
        if(images.size() > 0) {
            areImagesExist = true;
            result = "На странице " + images.size() + " тегов img (изображений)";
            int altCount = 0;

            for(Element img : images) {
                if(img.attributes().get("alt").length() != 0) {
                    altCount++;
                }
            }
            if (altCount == images.size()) {
                areAllImagesAlted = true;
                result += "\nВсе изображения img имеют альтернативный текст alt - ОК";
            } else {
                areAllImagesAlted = false;
                result += "\nНе все изображения img имеют альтернативный текст alt. " +
                        "Необходимо добавить недостающие аттрибуты alt";
            }
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
    public String getIncludedKeys(Element element, Boolean isIncludeKeys) {
        String result = "\n" + element.normalName() + " не содержит ключевых слов";
        isIncludeKeys = false;
        String[] elementWords = element.text().split(" ");
        int keysInElement = 0;

        for (String word : elementWords) {
            for (String key : keyWords) {
                if (WordsHandler.handle(word).toLowerCase().equals(key.toLowerCase())) {
                    isIncludeKeys = true;
                    keysInElement ++;
                }
            }
        }
        if (isIncludeKeys) {
            result = "\n" + element.normalName() + " содержит ключевые слова (количество слов: " + keysInElement + ") - ОК";
        }
        return result;
    }

    //проверка вхождения ключевых слов в текст строки
    public String getIncludedKeys(String elementText, String elementName, Boolean isIncludeKeys) {
        String result = "\n" + elementName + " не содержит ключевых слов";
        isIncludeKeys = false;
        String[] elementWords = elementText.split(" ");
        int keysInElement = 0;

        for (String word : elementWords) {
            for (String key : keyWords) {
                if (WordsHandler.handle(word).toLowerCase().equals(key.toLowerCase())) {
                    isIncludeKeys = true;
                    keysInElement ++;
                }
            }
        }
        if (isIncludeKeys) {
            result = "\n" + elementName + " содержит ключевые слова (количество слов: " + keysInElement + ") - ОК";
        }
        return result;
    }

    //проверка длины содержимого элемента
    public String checkLength(Element element, int minLength, int maxLength, Boolean isLengthOk) {
        String elementValue = element.text();
        //по умолчанию длина элемента меньше нормы
        isLengthOk = false;
        String result = "\nДлина " + element.normalName() + " составляет " + elementValue.length() +
                " символов - это меньше рекомендуемой длины";

        //проверка длины
        if (elementValue.length() >= minLength & elementValue.length() <= maxLength) {
            isLengthOk = true;
            result = "\nДлина " + element.normalName() + " составляет "+ elementValue.length() + " символов - ОК";
        } else if (elementValue.length() > maxLength ) {
            isLengthOk = false;
            result = "\nДлина " + element.normalName() + " составляет " + elementValue.length() +
                    " и превышает рекомендуемую длину в" + maxLength +" символов";
        }
        return result;
    }

    //проверка длины содержимого строки
    public String checkLength(String elementValue, String elementName, int minLength, int maxLength, Boolean isLengthOk) {
        //по умолчанию длина элемента меньше нормы
        isLengthOk = false;
        String result = "\nДлина " + elementName + " составляет " + elementValue.length() +
                " символов - это меньше рекомендуемой длины\n";

        //проверка длины
        if (elementValue.length() >= minLength & elementValue.length() <= maxLength) {
            isLengthOk = true;
            result = "\nДлина " + elementName + " составляет "+ elementValue.length() + " символов - ОК\n";
        } else if (elementValue.length() > maxLength ) {
            isLengthOk = false;
            result = "\nДлина " + elementName+ " составляет " + elementValue.length() +
                    " и превышает рекомендуемую длину в" + maxLength +" символов";
        }
        return result;
    }


    //Тесты для методов, использующие приватные поля

    //Тестирование парсинга веб-страницы, локального ресурса или строки
    @Test
    public void testParseHTML () {
        Parser parser = new Parser();
        Parser parser2 = new Parser();

        String address = "https://github.com/patronovskiy/817783-device";
        String debugHTML = "  <!DOCTYPE html>\n" +
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

        try {
            parser.parseHTML(address, true);
            File input = new File("testingHTML1.html");
            Document doc = Jsoup.parse(input, "UTF-8");
            Assert.assertEquals("Возможно страница, с которой сравнивается вывод, устарела. " +
                    "Проверьте актуальность данных", parser.document, doc);

            parser2.parseHTML("testingHTML1.html", true);
            Assert.assertEquals(parser2.document, doc);

            parser2.parseHTML(debugHTML, false);
            doc = Jsoup.parse(debugHTML);
            Assert.assertEquals(parser2.document, doc);

        } catch (IOException e) {

        }
    }

    //тестирование метода, устанавливающего ключевые слова
    @Test
    public void testSetKeys() {
        Parser parser = new Parser();
        String[] testKeys = {"key1", "key2", "key3"};
        parser.setKeys(testKeys);
        Assert.assertArrayEquals("Ключевые слова не установлены в методе setKeys()", testKeys, parser.keyWords);

        Parser parser2 = new Parser();
        testKeys = new String[0];
        Assert.assertArrayEquals("Ключевые слова не установлены в методе setKeys()", null, parser2.keyWords);
    }

}

