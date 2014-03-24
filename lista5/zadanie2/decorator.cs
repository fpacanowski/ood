using System.IO;

public class CaesarStream {
    private int Rotation;
    private Stream Stream;
    public CaesarStream( Stream stream, int rotation ) {
        Rotation = rotation;
        Stream = stream;
    }
    private void RotateBytes( byte[] buffer, int offset, int count ) {
        for( int i = 0; i < count; i++) {
            buffer[i+offset] = (byte)((buffer[i] + Rotation)%256);
        }
    }
    public void Write( byte[] buffer, int offset, int count ) {
        RotateBytes(buffer, offset, count);
        Stream.Write(buffer, offset, count);
    }
    public int Read( byte[] buffer, int offset, int count ) {
        int n = Stream.Read(buffer, offset, count);
        RotateBytes(buffer, offset, count);
        return n;
    }
}
