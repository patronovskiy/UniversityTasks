package Task3.Project2;

import Task3.Film;
import Task3.MyFilmsList;

import java.io.*;
import java.util.ArrayList;
import java.util.Scanner;

public class Task3Project2 {
    public static void main(String[] args) {
        //инициализировать предопределенный список фильмов
        MyFilmsList list = new MyFilmsList();
        ArrayList<Film> films = list.initialize();

        //дозаписать фильмы и вывести все фильмы
        try {
            //дозаписать, если пользователь введет "да"
            Scanner in = new Scanner(System.in);
            System.out.println("Хотите ли Вы записать информацию о фильмах? (в файле уже есть несколько фильмов)");
            System.out.println("Введите \"да\", чтобы добавить фильмы:");
            String answer = in.nextLine();
            if (answer.toLowerCase().equals("да")) {
                addFilms(in, list);
            }

            //вывести все фильмы из списка
            System.out.println("Все фильмы в списке: ");
            for (Film film : films) {
                System.out.println(film.toString());
            }
        } catch (Exception e) {
            System.out.println("Err:" + e);
        }


        try {
            //сериализовать и записать в первый файл
            File f1 = new File("Project2File1.txt");
            if (f1.exists()) {
                f1.delete();
            }
            f1.createNewFile();
            FileOutputStream fileOutputStream = new FileOutputStream(f1);
            ObjectOutputStream objectOutputStream = new ObjectOutputStream(fileOutputStream);

            objectOutputStream.writeObject(list);
            objectOutputStream.flush();
//            objectOutputStream.close();
//            fileOutputStream.close();


            //чтение объектов из первого файла и перезапись во второй файл фильмов со страной "Россия"
            //поток записи
            File f2 = new File("Project2File2.txt");
            if (f2.exists()) {
                f2.delete();
            }
            f2.createNewFile();
            FileOutputStream fileOutputStream2 = new FileOutputStream(f2);
            ObjectOutputStream objectOutputStream2 = new ObjectOutputStream(fileOutputStream2);

            //поток чтения
            FileInputStream fileInputStream = new FileInputStream(f1);
            ObjectInputStream objectInputStream = new ObjectInputStream(fileInputStream);

            //прочитать список фильмов из первого файла
            MyFilmsList loadedList = (MyFilmsList) objectInputStream.readObject();
            //выбрать фильмы и записать в новый список
            MyFilmsList russiaList = new MyFilmsList();
            russiaList.initializeEmpty();

            for (Film film : loadedList.myFilms) {
                if (film.getCountry().equals("Россия")) {
                    russiaList.addFilm(film);
                }
            }

            //записать полученный список в новый файл
            objectOutputStream2.writeObject(russiaList);

            //закрыть потоки
            objectOutputStream2.flush();
            objectOutputStream2.close();
            fileOutputStream2.close();

            //прочитать полученный второй файл и вывести
            fileInputStream = new FileInputStream(f2);
            objectInputStream = new ObjectInputStream(fileInputStream);

            MyFilmsList resultList = (MyFilmsList) objectInputStream.readObject();
            System.out.println("Фильмы, переписанные во второй файл:");
            for (Film film : resultList.myFilms) {
                System.out.println(film.toString());
            }

            fileInputStream.close();
            objectInputStream.close();

        } catch (IOException e) {
            System.out.println("IO Err: " + e);
        } catch (ClassNotFoundException e) {
            System.out.println("Class not found Err:" + e);
        }
    }



    //функция, добавляющая фильмы в список
    public static void addFilms(Scanner in, MyFilmsList myFilmsList) {
        int filmsQuantity = 0;
        System.out.println("Введите количество фильмов: ");
        filmsQuantity = in.nextInt();
        if (filmsQuantity < 0) {
            filmsQuantity = 0;
        }

        in.nextLine();
        for (int i = 0; i < filmsQuantity; i++) {
            System.out.println("Введите название фильма: ");
            String title = in.nextLine();

            System.out.println("Введите год выпуска: ");
            int year = in.nextInt();

            in.nextLine();
            System.out.println("Введите страну-производителя: ");
            String country = in.nextLine();

            System.out.println("Введите стоимость проката (если неизвестно, введите 0): ");
            int cost = in.nextInt();

            Film currentFilm = new Film(title, year, country, cost);
            myFilmsList.addFilm(currentFilm);
        }
    }
}
