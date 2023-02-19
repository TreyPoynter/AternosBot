# Import
import sys
from python_aternos import Client
from python_aternos import ServerStartError

# Log in
aternos = Client.from_credentials('ButterBurener', 'Dirtsucks1')

# Returns AternosServer list
servs = aternos.list_servers()

# Get the first server by the 0 index
myserv = servs[0]

# Start
myserv.start()
# Stop
myserv.stop()

# You can also find server by IP
currServer = None
for serv in servs:
    if serv.address == 'ButterBurener.aternos.me':
        currServer = serv

serverIsStarted = False;

if currServer is not None:
   try:
        currServer.start()
        serverIsStarted = True;
   except ServerStartError as err:
        print(err.code)
        print(err.message)
        serverIsStarted = False;
else:
    print('Server not found')

if serverIsStarted:
    print(serverIsStarted)

