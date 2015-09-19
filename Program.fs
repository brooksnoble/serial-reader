open System
open System.IO
open System.IO.Ports

[<EntryPoint>]
let main argv = 
    let myPort = new SerialPort()

    myPort.PortName <- "/dev/tty.usbmodemfd121"
    myPort.BaudRate <- 9600
    myPort.DataBits <- 8
    myPort.Parity <- Parity.None
    myPort.StopBits <- StopBits.One

    myPort.Open()

    while true do
        let value = myPort.ReadTo("\r\n")

        match System.Int32.TryParse(value) with
        | (true, value) ->
            printfn "%d" value
        | _ -> 
            printfn "Bad: %s" value

    myPort.Close()

    0
