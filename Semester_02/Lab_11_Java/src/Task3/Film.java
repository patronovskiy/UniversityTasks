package Task3;

import java.io.Serializable;

public class Film implements Serializable {
    String title;
    int year;
    String country;
    int cost;

    public Film(String title, int year, String country, int cost) {
        this.title = title;
        this.year = year;
        this.country = country;
        this.cost = cost;
    }

    public String getCountry() {
        return this.country;
    }

    @Override
    public String toString() {
        String description =    "Название: " + this.title +
                                "\nГод выпуска: " + this.year +
                                "\nСтрана: " + this.country;
        if (this.cost == 0) {
            description += "\nCтоимость проката $: неизвестно\n";
        } else {
            description += "\nСтоимость проката $: " + this.cost +"\n";
        }
        return description;
    }

    //метод для создания записи с разделителями
    public String toRandomAccessString() {
        String description =    this.title +
                "%" + this.year +
                "%" + this.country +
                "%" + this.cost;
        return description;
    }
}

// Название_фильма,    год_выпуска,   страна,   жанр,  стоимость_проката.