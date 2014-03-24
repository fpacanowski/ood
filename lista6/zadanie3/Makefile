all: visitor.dll visitor_test.dll

visitor.dll: visitor.cs
	mcs -t:library visitor.cs

visitor_test.dll: visitor_test.cs visitor.dll
	mcs -t:library -r:nunit.framework,visitor.dll visitor_test.cs

test: all
	nunit-console visitor_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
