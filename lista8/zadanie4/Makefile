all: state.dll state_test.dll

state.dll: state.cs
	mcs -t:library state.cs

state_test.dll: state_test.cs state.dll
	mcs -t:library -r:nunit.framework,state.dll state_test.cs

test: all
	nunit-console state_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
