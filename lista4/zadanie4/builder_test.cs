using System;
using System.IO;
using NUnit.Framework;

[TestFixture]
public class TagBuilderTest
{
    TagBuilder tag;
    StringWriter writer;
    private String BuildSomeDocument(){
        tag.StartTag( "parent" )
        .AddAttribute( "parentproperty1", "true" )
        .AddAttribute( "parentproperty2", "5" )
        .StartTag( "child1")
        .AddAttribute( "childproperty1", "c" )
        .AddContent( "childbody" )
        .EndTag()
        .StartTag( "child2" )
        .AddAttribute( "childproperty2", "c" )
        .AddContent( "childbody" )
        .EndTag()
        .EndTag()
        .StartTag( "script" )
        .AddContent( "$.scriptbody();")
        .EndTag();

        return writer.ToString();
    }
    [SetUp]
    public void CreateTagBuilder(){
        writer = new StringWriter();
        tag = new TagBuilder( writer );
    }

    [Test]
    public void NoIndent(){
        //tag.IsIndnted = true;
        //tag.Indentation = 4;
        String output = BuildSomeDocument();
        Assert.AreEqual(output, "<parent parentproperty1='true' parentproperty2='5'><child1 childproperty1='c'>childbody</child1><child2 childproperty2='c'>childbody</child2></parent><script>$.scriptbody();</script>");
    }

    [Test]
    public void ZeroSizeIndent(){
        tag.IsIndented = true;
        //tag.Indentation = 4;
        String output = BuildSomeDocument();
        /* expected output:
        <parent parentproperty1='true' parentproperty2='5'>
        <child1 childproperty1='c'>
        childbody
        </child1>
        <child2 childproperty2='c'>
        childbody
        </child2>
        </parent>
        <script>
        $.scriptbody();
        </script>
        */
        Assert.AreEqual(output, "<parent parentproperty1='true' parentproperty2='5'>\n<child1 childproperty1='c'>\nchildbody\n</child1>\n<child2 childproperty2='c'>\nchildbody\n</child2>\n</parent>\n<script>\n$.scriptbody();\n</script>\n");
    }

    [Test]
    public void SomeIndent(){
        tag.IsIndented = true;
        tag.Indentation = 2;
        String output = BuildSomeDocument();
        /* expected output:
        <parent parentproperty1='true' parentproperty2='5'>
          <child1 childproperty1='c'>
            childbody
          </child1>
          <child2 childproperty2='c'>
           childbody
          </child2>
        </parent>
        <script>
          $.scriptbody();
        </script>
        */
        Assert.AreEqual(output, "<parent parentproperty1='true' parentproperty2='5'>\n  <child1 childproperty1='c'>\n    childbody\n  </child1>\n  <child2 childproperty2='c'>\n    childbody\n  </child2>\n</parent>\n<script>\n  $.scriptbody();\n</script>\n");
    }
}
