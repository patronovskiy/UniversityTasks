package logic;

import controllers.MainScreenController;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.io.IOException;

public class Main extends Application {

    @Override
    public void start(Stage stage) throws Exception {
        Parent root = FXMLLoader.load(getClass().getResource("../resources/mainScreen.fxml"));
        stage.setTitle("Парсер для поисковой оптимизации");

        MainScreenController controller = new MainScreenController();
        controller.initialize();


        stage.setScene(new Scene(root));
        stage.show();
    }


    public static void main(String[] args) {

        launch(args);

//        String address = "https://seo-akademiya.com/baza-znanij/vnutrennyaya-optimizacziya/atributyi-alt-i-title/";
//        String debugHTML = "  <!DOCTYPE html>\n" +
//                "  <html lang=\"ru\">\n" +
//                "    <head>\n" +
//                "      <meta charset=\"utf-8\">\n" +
//                "<meta name=\"description\" content=\"ааа мир\"" +
//                "      <title>Привет, мир!!!!!!!</title>\n" +
//                "    </head>\n" +
//                "    <body>\n" +
//                "      <h1>Привет, мир!</h1>\n" +
//                "      <p>Это веб-страница.</p>\n" +
//                "<div><h2></h2><h4></h4></div>"+ "<h3></h3>" +
//                "<img alt=\"alt\">" +
//                "    </body>\n" +
//                "  </html>\n";
//        String[] keys = {"Vbh", "МИР"};
//        try {
//            Parser parser = new Parser();
//            parser.parseHTML(debugHTML, false);
//            parser.setKeys(keys);
//            parser.start();
//
//        } catch (IOException e) {
//            System.out.println("IO err 1: " + e);
//        }

    }


}
