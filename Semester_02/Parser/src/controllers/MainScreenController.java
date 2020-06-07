package controllers;

import javafx.event.ActionEvent;
import javafx.scene.control.*;
import logic.Parser;

import java.io.*;

public class MainScreenController {
    //ЭЛЕМЕНТЫ ИНТЕРФЕЙСА
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

    //вкладка с результатами
    public TextArea resultWindow = new TextArea();
    public Tab tabResult = new Tab();
    public TabPane tabPane = new TabPane();
    public Button buttonSave = new Button();
    public TextField textFieldSaveAddress = new TextField();

    public Button ButtonSavedOk = new Button();
    public ProgressBar savingProgressBar = new ProgressBar();
    public Label savedLabel = new Label();

    //состояние программы
    boolean isParsed = false;


    //ЛОГИКА РАБОТЫ ИНТЕРФЕЙСА
    //инициализация свойств окна
    public void initialize() {
        //радиокнопки выбора типа ресурса
        radioResoursesString.setToggleGroup(resourseTypeRadios);
        radioResourseAddress.setToggleGroup(resourseTypeRadios);
        radioResourseAddress.setSelected(true);

        savingProgressBar.setOpacity(0);
        savingProgressBar.setProgress(0);
        savedLabel.setText("");
    }

    //парсинг по нажатию кнопки
    public void startParsingAction(ActionEvent actionEvent) {
        //очистка предыдущих отчетов
        savingProgressBar.setOpacity(0);
        savingProgressBar.setProgress(0);
        savedLabel.setText("");
        resultWindow.setText("");

        try {
            //создаем экземпляр парсера
            Parser parser = new Parser();
            //выгружаем из окна введенный текст
            String resource = textAreaResource.getText();
            //проверяем тип ресурса
            boolean isUrl = radioResourseAddress.isSelected();
            //получаем объект Document, т.е. проводим собственно парсинг
            parser.parseHTML(resource, isUrl);
            //задаем ключевые слова
            if (checkboxIsKeysCheck.isSelected()) {
                parser.setKeys(parser.getKeys(textAreaKeys.getText()));
            }
            //анализ выбранных элементов
            parseResult = parser.start(  checkboxTitle.isSelected(),
                                    checkboxHeaders.isSelected(),
                                    checkboxFormatTags.isSelected(),
                                    checkboxDescription.isSelected(),
                                    checkboxAlt.isSelected());
            //отображаем отчет во второй вкладке
            resultWindow.setText(parseResult);
            isParsed = true;
            tabPane.getSelectionModel().select(tabResult);

        } catch (IOException e) {
            isParsed = false;
            System.out.println("Ошибка ввода-вывода: " + e);
        } catch (Exception e) {
            isParsed = false;
            System.out.println("Ошибка: " + e);
        }
    }

    public void checkKeysOnAction(ActionEvent actionEvent) {
        if (checkboxIsKeysCheck.isSelected()) {
            textAreaKeys.setDisable(false);
        } else {
            textAreaKeys.setDisable(true);
        }
    }

    public void saveOnAction(ActionEvent actionEvent) {
        savingProgressBar.setOpacity(0);
        savingProgressBar.setProgress(0);
        savedLabel.setText("");
        savingProgressBar.setOpacity(100);
        if (isParsed == true) {
            try{
                savingProgressBar.setProgress(25);
                String address = textFieldSaveAddress.getText();
                if (address.length() == 0) {
                    address = "отчет.txt";
                }
                saveReport(parseResult, address);
                savingProgressBar.setProgress(50);
                savingProgressBar.setProgress(100);
                savedLabel.setText("Отчет сохранен по адресу: " + address);
                System.out.println("Отчет сохранен");
            } catch (IOException e) {
                System.out.println("Ошибка ввода-вывода при сохранении отчета: " + e);
            } catch (Exception e) {

            }
        }
    }

    public static void saveReport(String reportText, String address) throws IOException {
        BufferedWriter bw = null;
        try {
            // Создание потока записи с нужной кодировкой
            bw = new BufferedWriter
                    (new OutputStreamWriter
                            (new FileOutputStream(address), "UTF8"));

            // Запись
            bw.write(reportText);

        } catch (IOException e) {
            System.out.println("Ошибка ввода-вывода при сохранении отчета: " + e);
        } finally {
            bw.flush();
            bw.close();
        }
    }

}
