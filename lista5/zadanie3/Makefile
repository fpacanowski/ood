all: pool.dll pool_test.dll

pool.dll: pool.cs
	mcs -t:library pool.cs

pool_test.dll: pool_test.cs pool.dll
	mcs -t:library -r:nunit.framework,pool.dll pool_test.cs

test: all
	nunit-console pool_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
