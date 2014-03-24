all: builder.dll builder_test.dll

builder.dll: builder.cs
	mcs -t:library builder.cs

builder_test.dll: builder_test.cs builder.dll
	mcs -t:library -r:nunit.framework,builder.dll builder_test.cs

test: all
	nunit-console builder_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
