all: decorator.dll decorator_test.dll

decorator.dll: decorator.cs
	mcs -t:library decorator.cs

decorator_test.dll: decorator_test.cs decorator.dll
	mcs -t:library -r:nunit.framework,decorator.dll decorator_test.cs

test: all
	nunit-console decorator_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
