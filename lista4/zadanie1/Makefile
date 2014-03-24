all: singleton.dll singleton_test.dll

singleton.dll: singleton.cs
	mcs -t:library singleton.cs

singleton_test.dll: singleton_test.cs singleton.dll
	mcs -t:library -r:nunit.framework,singleton.dll singleton_test.cs

test: all
	nunit-console singleton_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
