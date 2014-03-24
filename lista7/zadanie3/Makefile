all: main.exe 

main.exe: main.cs
	mcs -pkg:gtk-sharp-2.0,mono-cairo -resource:gui.glade main.cs

app.dll: app.cs
	mcs -t:library app.cs

memento_test.dll: memento_test.cs app.dll
	mcs -t:library -r:nunit.framework,app.dll memento_test.cs

test: memento_test.dll
	nunit-console memento_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
