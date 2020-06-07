package controllers;

import javafx.event.ActionEvent;
import javafx.scene.control.CheckBox;
import javafx.scene.control.RadioButton;
import javafx.scene.control.TextArea;
import javafx.scene.control.ToggleGroup;
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

    //инициализация свойств окна
    public void initialize() {
        //радиокнопки выбора типа ресурса
        radioResoursesString.setToggleGroup(resourseTypeRadios);
        radioResourseAddress.setToggleGroup(resourseTypeRadios);
        radioResourseAddress.setSelected(true);

        //окно ввода строки или адреса ресурса


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
            parser.start();


        } catch (IOException e) {
            System.out.println("Ошибка ввода-вывода: " + e);
        } catch (Exception e) {
            System.out.println("Ошибка: " + e);
        }





    }
}
