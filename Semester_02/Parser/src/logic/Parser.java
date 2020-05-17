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

    public void setKeys(String ... keys) {
        this.keyWords = keys;
    }

    public void start() {
        checkTitle();
        checkHeaders();
        checkFormattingTags();
        checkDescription();
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
            result = "Элемента title нет на странице";
        } else {
            isTitleExisting = true;

            //проверка того, что это единственный элемент на странице
            if (pageTitles.size() == 1) {
                isTitleUnique = true;
                result += "\nЭлемент title уникален на странице - ОК\n";
            } else {
                isTitleUnique = false;
                result += "\nЭлемент title не уникален на странице";
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
                "Рекомендуется добавить тег <meta name=\"description\" content=\"описание в 70-200 символов\">";

        Elements elementsWithNameDescription = this.document.getElementsByAttributeValue("name", "description");
        int metaDescriptions = 0;
        for (Element element : elementsWithNameDescription) {
            if (element.normalName().equals("meta")) {
                metaDescriptions ++;
            }
        }
        if (metaDescriptions == 1) {
            result = "\nСтраница содержит описание в мета-теге <meta name=\"description\"> - OK";

            Element metaDescription = elementsWithNameDescription.first();
            //извлекаем текст описания
            String description = metaDescription.attr("content");
            result += checkLength(metaDescription, 70, 200, isDescriptionLengthOk);
            if (keyWords != null) {
                result += getIncludedKeys(metaDescription, getIsDescriptionIncludeKeys);
            }

        } else if (metaDescriptions > 1) {
            result = "\nСтраница содержит более 1 мета-тега <meta name=\"description\">." +
                    "Этот тег должен быть единственным на странице.";
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
        String result = element.normalName() + " не содержит ключевых слов\n";
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
