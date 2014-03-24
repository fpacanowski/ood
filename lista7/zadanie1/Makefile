all: chain_of_responsibility.dll chain_of_responsibility_test.dll

chain_of_responsibility.dll: chain_of_responsibility.cs
	mcs -t:library chain_of_responsibility.cs

chain_of_responsibility_test.dll: chain_of_responsibility_test.cs chain_of_responsibility.dll
	mcs -t:library -r:nunit.framework,chain_of_responsibility.dll chain_of_responsibility_test.cs

test: all
	nunit-console chain_of_responsibility_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
