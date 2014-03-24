all: interpreter.dll interpreter_test.dll

interpreter.dll: interpreter.cs
	mcs -t:library interpreter.cs

interpreter_test.dll: interpreter_test.cs interpreter.dll
	mcs -t:library -r:nunit.framework,interpreter.dll interpreter_test.cs

test: all
	nunit-console interpreter_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
