all: factory.dll factory_test.dll

factory.dll: factory.cs
	mcs -t:library factory.cs

factory_test.dll: factory_test.cs factory.dll
	mcs -t:library -r:nunit.framework,factory.dll factory_test.cs

test: all
	nunit-console factory_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
