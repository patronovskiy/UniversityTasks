package logic;

import controllers.MainScreenController;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;


public class Main extends Application {

    @Override
    public void start(Stage stage) throws Exception {
        //установка сцены (экрана)
        Parent root = FXMLLoader.load(getClass().getResource("../resources/mainScreen.fxml"));

        stage.setTitle("Парсер для поисковой оптимизации");

        MainScreenController controller = new MainScreenController();
        controller.initialize();

        stage.setScene(new Scene(root));
        stage.show();
    }


    public static void main(String[] args) {
        //Запуск приложения
        launch(args);
    }
}
