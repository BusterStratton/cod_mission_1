using System;

public class AiAirport {

    private string _name;
    public Point3d Pos()
    {
        return new Point3d();
    }

    public int FieldR()
    {
        return 100;
    }

    public string Name(){
        return _name;
    }

    public AiAirport(string name){
        _name = name;
    }
}