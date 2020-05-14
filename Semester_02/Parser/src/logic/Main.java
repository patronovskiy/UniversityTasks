package logic;

import java.io.IOException;

public class Main {
    public static void main(String[] args) {
        String address = "https://seo-akademiya.com/baza-znanij/vnutrennyaya-optimizacziya/atributyi-alt-i-title/";
        String[] keys = {"alt", "SeO", "aaaa"};
        try {
            Parser parser = new Parser();
            parser.parseHTML(address, true);
            parser.checkTitle(keys);
        } catch (IOException e) {
            System.out.println("IO err 1: " + e);
        }

    }
}
