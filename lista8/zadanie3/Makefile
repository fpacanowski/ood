all: strategy.exe

strategy.exe: strategy.cs
	mcs -r:System.Data.dll -r:Mono.Data.Sqlite.dll strategy.cs

test: all
	nunit-console strategy_test.dll

clean:
	rm -f *.exe *.dll TestResult.xml
