all: command.exe

command.exe: command.cs
	mcs -r:System.Data.dll -r:Mono.Data.Sqlite.dll command.cs

test: all
	nunit-console command_test.dll

clean:
	rm -f *.exe *.dll test/*
