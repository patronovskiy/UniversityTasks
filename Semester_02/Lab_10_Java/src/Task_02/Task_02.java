package Task_02;

        import java.io.ByteArrayInputStream;
        import java.io.FileInputStream;
        import java.io.IOException;
        import java.io.InputStream;
        import java.net.URL;

public class Task_02 {
    public static void main(String[] args) throws IOException {
        try {
            //the stream is associated with the file
            InputStream inFile = new FileInputStream("text.txt");
            readAllByByte(inFile);
            System.out.println("\n\n\n");
            inFile.close();

            //the stream is associated with web page
            InputStream inUrl = new URL("http://google.com").openStream();
            readAllByByte(inUrl);
            System.out.println("\n\n\n");
            inUrl.close();

            //the stream ia associated with the byte array
            InputStream inArray = new ByteArrayInputStream(new byte [] {77, 69, 63, 67, 64});
            readAllByByte(inArray);
            System.out.println("\n\n\n");
            inArray.close();

        } catch (IOException e) {

        }
    }

    //Method that reads data from stream by one byte with output
    public static void readAllByByte(InputStream in) throws IOException {
        while(true) {
            int oneByte = in.read();
            if (oneByte != -1) {
                System.out.print((char) oneByte);
            } else {
                System.out.println("\n" + "end");
                break;
            }
        }
    }
}
