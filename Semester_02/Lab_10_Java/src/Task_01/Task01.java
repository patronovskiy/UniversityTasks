package Task_01;


import java.io.File;

public class Task01 {
    public static void main(String[] args) {
        try {
            //Create file in the current folder
            File f1 = new File("MyFile.txt");
            f1.createNewFile();
            if (f1.exists()) {
                System.out.println("File is created");
                System.out.println("Full path 1: " + f1.getAbsolutePath());
            }

            //Create file on disk C (need administrative rights)
            File f2 = new File("C:\\MyFile2.txt");
            f2.createNewFile();
            System.out.println("Full path 2: " + f2.getAbsolutePath());

            File f3 = new File("Folder1\\Folder2\\Folder3\\");
            f3.mkdirs();
            System.out.println("Full path 3: " + f3.getAbsolutePath());

        } catch (Exception e) {
            System.out.println("Error: " + e);
        }
    }
}
