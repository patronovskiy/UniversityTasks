package Task3;

import java.io.Serializable;
import java.util.ArrayList;

public class MyFilmsList implements Serializable {
    public ArrayList<Film> myFilms;

    public void initializeEmpty() {
        myFilms = new ArrayList();
    }

    public ArrayList<Film> initialize() {
        myFilms = new ArrayList();

        myFilms.add(new Film(
                "Властелин колец: Возвращение короля",
                2003,
                "Новая Зеландия, США",
                1_118_887_224));

        myFilms.add(new Film(
                "Унесенные призраками",
                2001,
                "Япония",
                274_925_095));

        myFilms.add(new Film(
                "Дурак",
                2014,
                "Россия",
                15_554));

        myFilms.add(new Film(
                "Сирота казанская",
                1997,
                "Россия",
                0));

        return myFilms;
    }

    public void addFilm(Film film) {
        myFilms.add(film);
    }
}
