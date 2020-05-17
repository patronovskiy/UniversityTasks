package logic;

import java.io.IOException;

public class Main {
    public static void main(String[] args) {
        String address = "https://seo-akademiya.com/baza-znanij/vnutrennyaya-optimizacziya/atributyi-alt-i-title/";
        String debugHTML = "  <!DOCTYPE html>\n" +
                "  <html lang=\"ru\">\n" +
                "    <head>\n" +
                "      <meta charset=\"utf-8\">\n" +
                "      <title>Привет, мир!!!!!</title>\n" +
                "    </head>\n" +
                "    <body>\n" +
                "      <h1>Привет, мир!</h1>\n" +
                "      <p>Это веб-страница.</p>\n" +
                "<div><h2></h2><h4></h4></div>"+ "<h3></h3>" +
                "    </body>\n" +
                "  </html>\n";
        String[] keys = {"alt", "SeO", "aaaa", "мир"};
        try {
            Parser parser = new Parser();
            parser.parseHTML(debugHTML, false);
            parser.checkTitle(keys);
            parser.checkHeaders(keys);
        } catch (IOException e) {
            System.out.println("IO err 1: " + e);
        }

    }
}
