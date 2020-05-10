package Task3.Project1;

import Task3.Film;
import Task3.MyFilmsList;

import java.io.EOFException;
import java.io.File;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.ArrayList;
import java.util.Scanner;

public class Task3Project1 {
    public static void main(String[] args) {
        //инициализировать предопределенный список фильмов
        MyFilmsList myFilmsList = new MyFilmsList();
        ArrayList<Film> films = myFilmsList.initialize();

        //дозаписать фильмы и вывести все фильмы
        try {
            //дозаписать, если пользователь введет "да"
            Scanner in = new Scanner(System.in);
            System.out.println("Хотите ли Вы записать информацию о фильмах? (в файле уже есть несколько фильмов)");
            System.out.println("Введите \"да\", чтобы добавить фильмы:");
            String answer = in.nextLine();
            if (answer.toLowerCase().equals("да")) {
                addFilms(in, films);
            }

            //вывести все фильмы из списка  TODO
            System.out.println("Все фильмы в списке: ");
            for (Film film : films) {
                System.out.println(film.toString());
            }
        } catch (Exception e) {
            System.out.println("Err:" + e);
        }


        try {
            //создать файл со всеми фильмами
            File file1 = new File("Project1File1.txt");
            if (file1.exists()) {
                file1.delete();
            }
            file1.createNewFile();

            RandomAccessFile randFile = new RandomAccessFile(file1, "rw");
            for (int i = 0; i < films.size(); i++) {
                randFile.writeUTF(films.get(i).toRandomAccessString());
            }
            randFile.writeUTF("\n^");
            randFile.close();

            //прочитать файл со всеми фильмами, выбрать нужные и переписать в новый файл

            //файл со всеми фильмами
            RandomAccessFile randFile2 = new RandomAccessFile(file1, "r");
            //новый файл с фильмами, снятыми в России
            File file2 = new File("Project1File2.txt");
            if (file2.exists()) {
                file2.delete();
            }
            file2.createNewFile();
            RandomAccessFile randFile3 = new RandomAccessFile(file2, "rw");
            randFile2.seek(0);

            String currentString;
            ArrayList<Film> readFilms= new ArrayList<>();

            while (!(currentString = randFile2.readUTF()).equals("\n^")) {
                    String[] filmParameters = currentString.split("%");
                    if(filmParameters[2].toLowerCase().equals("россия")) {
                        Film film = new Film(filmParameters[0], Integer.parseInt(filmParameters[1]), filmParameters[2], Integer.parseInt(filmParameters[3]));
                        randFile3.writeUTF(film.toString());
                    }
            }
            randFile2.close();
            randFile3.close();

            //прочитать результирующий файл
            System.out.println("Фильмы производства России, записанные во второй файл:");
            RandomAccessFile resultFile = new RandomAccessFile(file2, "r");
            while(resultFile.getFilePointer() != resultFile.length()) {
                System.out.println(resultFile.readUTF());
            }

        } catch (EOFException e1) {
            System.out.println("\nEnd of file");
        } catch (IOException e) {
            System.out.println("IO Error: " + e);
        }

    }

    //функция, добавляющая фильмы в список
    public static void addFilms(Scanner in, ArrayList<Film> films) {
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
            films.add(currentFilm);
        }
    }
}

//1-й проект –работа с файлом с произвольным доступом
//Записать   в   исходный   файл   информацию   о   фильмах:
// Название_фильма,    год_выпуска,   страна,   жанр,  стоимость_проката.
// Количество фильмов задать с клавиатуры.
//Создать программным способом другой файл и переписать в него информацию о фильмах, выпущенных в России.
