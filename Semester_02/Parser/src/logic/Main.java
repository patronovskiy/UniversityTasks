package java;

import java.io.IOException;

public class Main {
    public static void main(String[] args) {
        String address = "https://jsoup.org/cookbook/extracting-data/working-with-urls";
        try {
            Parser parser = new Parser();
            parser.parseHTML(address, true);
            parser.checkTitle();
        } catch (IOException e) {
            System.out.println("IO err 1: " + e);
        }


    }
}
