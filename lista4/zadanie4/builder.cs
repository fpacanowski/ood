using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

public class TagBuilder
{
    public TagBuilder(StringWriter writer) { output = writer; }
    public TagBuilder( string TagName, TagBuilder Parent, int IndentLevel)
    {
        this.tagName = TagName;
        this.parent = Parent;
        this.indentLevel = IndentLevel;
    }
    private string        tagName;
    private TagBuilder    parent;
    private StringBuilder body = new StringBuilder();
    private Dictionary<string, string> _attributes = new Dictionary<string, string>();
    private StringWriter output;
    private int indentLevel = 0;
    public int Indentation { get; set;}
    public bool IsIndented { get;  set;}

    private String IndentString() {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < indentLevel; i++)
            sb.Append(" ");
        return sb.ToString();
    }

    public TagBuilder AddContent( string Content )
    {
        StringBuilder toWrite = new StringBuilder();
        string[] lines = Content.Split('\n');
        foreach(string line in lines) {
            if(IsIndented) toWrite.Append(IndentString());
            toWrite.Append( line );
            if(IsIndented) toWrite.Append("\n");
        }

        body.Append(toWrite.ToString());
        if(output != null) output.Write(toWrite.ToString());
        return this;
    }

    public TagBuilder StartTag( string TagName )
    {
        TagBuilder tag = new TagBuilder( TagName, this, indentLevel + Indentation );
        tag.IsIndented = IsIndented;
        return tag;
    }
 
    public TagBuilder EndTag()
    {
        parent.AddContent( this.ToString() );
        return parent;
    }
 
    public TagBuilder AddAttribute( string Name, string Value )
    {
        _attributes.Add( Name, Value );
        return this;
    }

    public override string ToString()
    {
        StringBuilder tag = new StringBuilder();

        // preamble
        if ( !string.IsNullOrEmpty( this.tagName ) )
            tag.AppendFormat( "<{0}", tagName );

        if ( _attributes.Count > 0 )
        {
            tag.Append( " " );
            tag.Append( 
                string.Join( " ", 
                    _attributes
                        .Select( 
                            kvp => string.Format( "{0}='{1}'", kvp.Key, kvp.Value ) )
                        .ToArray() ) );
        }

        // body/ending
        if ( body.Length > 0 )
        {
            if ( !string.IsNullOrEmpty( this.tagName) || this._attributes.Count > 0 ){
                tag.Append( ">" );
                if(IsIndented) tag.Append("\n");
                }
            tag.Append( body.ToString() );
            if ( !string.IsNullOrEmpty( this.tagName ) ) {
                tag.AppendFormat( "</{0}>", this.tagName );
            }
        }
        else
            if ( !string.IsNullOrEmpty( this.tagName ) )
                tag.Append( "/>" );


        return tag.ToString();
    }
}
