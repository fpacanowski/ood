all: template_method.exe

template_method.exe: template_method.cs
	mcs -r:System.Data.dll -r:Mono.Data.Sqlite.dll template_method.cs

test: all
	nunit-console template_method_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
