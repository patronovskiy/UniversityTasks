package controllers;

import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.stage.Stage;
import javafx.stage.WindowEvent;
import logic.Parser;

import java.io.IOException;

public class MainScreenController {
    //радиокнопки выбора типа ресурса
    public RadioButton radioResourseAddress = new RadioButton();
    public RadioButton radioResoursesString = new RadioButton();
    public ToggleGroup resourseTypeRadios = new ToggleGroup();
    //окно ввода строки или адреса ресурса
    public TextArea textAreaResource = new TextArea();
    //окно ввода ключевых слов и чекбокс
    public TextArea textAreaKeys = new TextArea();
    public CheckBox checkboxIsKeysCheck = new CheckBox();

    //чекбоксы для выбора проверяемых элементов
    public CheckBox checkboxTitle = new CheckBox();
    public CheckBox checkboxHeaders = new CheckBox();
    public CheckBox checkboxFormatTags = new CheckBox();
    public CheckBox checkboxDescription = new CheckBox();
    public CheckBox checkboxAlt = new CheckBox();

    //переменная для сохранения результата парсинга
    public String parseResult;

    //окно с результатами
    public TextArea resultWindow = new TextArea();
    public Tab tabResult = new Tab();
    public TabPane tabPane = new TabPane();

    public Button buttonSave = new Button();
    public TextField textFieldSaveAddress = new TextField();

    public Button buttonShowRequirments = new Button();

    //инициализация свойств окна
    public void initialize() {
        //радиокнопки выбора типа ресурса
        radioResoursesString.setToggleGroup(resourseTypeRadios);
        radioResourseAddress.setToggleGroup(resourseTypeRadios);
        radioResourseAddress.setSelected(true);

    }

    //парсинг по нажатию кнопки
    public void startParsingAction(ActionEvent actionEvent) {
        try {
            //создаем экземпляр парсера
            Parser parser = new Parser();
            //выгружаем из окна введенный текст
            String resource = textAreaResource.getText();
            System.out.println(resource);
            //проверяем тип ресурса
            boolean isUrl = radioResourseAddress.isSelected();
//            //получаем объект Document, т.е. проводим собственно парсинг
            parser.parseHTML(resource, isUrl);
//            //задаем ключевые слова
            if (checkboxIsKeysCheck.isSelected()) {
                parser.setKeys(parser.getKeys(textAreaKeys.getText()));
            }
            //анализ выбранных элементов
            parseResult = parser.start(  checkboxTitle.isSelected(),
                                    checkboxHeaders.isSelected(),
                                    checkboxFormatTags.isSelected(),
                                    checkboxDescription.isSelected(),
                                    checkboxAlt.isSelected());



            resultWindow.setText(parseResult);
            tabPane.getSelectionModel().select(tabResult);
            System.out.println("TEXT" + resultWindow.getText());




        } catch (IOException e) {
            System.out.println("Ошибка ввода-вывода: " + e);
        } catch (Exception e) {
            System.out.println("Ошибка: " + e);
        }
    }

}
