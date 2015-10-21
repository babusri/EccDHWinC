using System;
using System.Windows.Input;

using System.Security.Cryptography;
using Elliptic;
using System.ComponentModel;

namespace EccDHWinC.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(String info) {
      if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(info));
      }
    }

    private ICommand genAliceRandomCommand;
    private ICommand computeAlicePrivateFromRandomCommand;
    private ICommand computeAlicePublicFromPrivateCommand;

    private ICommand genBobRandomCommand;
    private ICommand computeBobPrivateFromRandomCommand;
    private ICommand computeBobPublicFromPrivateCommand;

    private ICommand computeAliceBobSharedCommand;
    private ICommand computeBobAliceSharedCommand;

    public ICommand GenAliceRandomCommand
    {
      get
        {
          return genAliceRandomCommand;
        }
      set
        {
          genAliceRandomCommand = value;
        }
    }

    public ICommand ComputeAlicePrivateFromRandomCommand
    {
      get
        {
          return computeAlicePrivateFromRandomCommand;
        }
      set
        {
          computeAlicePrivateFromRandomCommand = value;
        }
    }

    public ICommand ComputeAlicePublicFromPrivateCommand
    {
      get
        {
          return computeAlicePublicFromPrivateCommand;
        }
      set
        {
          computeAlicePublicFromPrivateCommand = value;
        }
    }

    public ICommand GenBobRandomCommand
    {
      get
        {
          return genBobRandomCommand;
        }
      set
        {
          genBobRandomCommand = value;
        }
    }


    public ICommand ComputeBobPrivateFromRandomCommand
    {
      get
        {
          return computeBobPrivateFromRandomCommand;
        }
      set
        {
          computeBobPrivateFromRandomCommand = value;
        }
    }


    public ICommand ComputeBobPublicFromPrivateCommand
    {
      get
        {
          return computeBobPublicFromPrivateCommand;
        }
      set
        {
          computeBobPublicFromPrivateCommand = value;
        }
    }

    public ICommand ComputeAliceBobSharedCommand
    {
      get
        {
          return computeAliceBobSharedCommand;
        }
      set
        {
          computeAliceBobSharedCommand = value;
        }
    }


    public ICommand ComputeBobAliceSharedCommand
    {
      get
        {
          return computeBobAliceSharedCommand;
        }
      set
        {
          computeBobAliceSharedCommand = value;
        }
    }

    private string _aliceRandomText;
    public string AliceRandomText
    {
      get { return _aliceRandomText; }
      set {
        _aliceRandomText = value;
        NotifyPropertyChanged("AliceRandomText");
      }
    }

    private string _alicePrivateKeyText;
    public string AlicePrivateKeyText
    {
      get { return _alicePrivateKeyText; }
      set {
        _alicePrivateKeyText = value;
        NotifyPropertyChanged("AlicePrivateKeyText");
      }
    }

    private string _alicePublicKeyText;
    public string AlicePublicKeyText
    {
      get { return _alicePublicKeyText; }
      set {
        _alicePublicKeyText = value;
        NotifyPropertyChanged("AlicePublicKeyText");
      }
    }

    private string _bobRandomText;
    public string BobRandomText
    {
      get { return _bobRandomText; }
      set {
        _bobRandomText = value;
        NotifyPropertyChanged("BobRandomText");
      }
    }

    private string _bobPrivateKeyText;
    public string BobPrivateKeyText
    {
      get { return _bobPrivateKeyText; }
      set {
        _bobPrivateKeyText = value;
        NotifyPropertyChanged("BobPrivateKeyText");
      }
    }

    private string _bobPublicKeyText;
    public string BobPublicKeyText
    {
      get { return _bobPublicKeyText; }
      set {
        _bobPublicKeyText = value;
        NotifyPropertyChanged("BobPublicKeyText");
      }
    }

    private string _aliceBobSharedKeyText;
    public string AliceBobSharedKeyText
    {
      get { return _aliceBobSharedKeyText; }
      set {
        _aliceBobSharedKeyText = value;
        NotifyPropertyChanged("AliceBobSharedKeyText");
      }
    }

    private string _bobAliceSharedKeyText;
    public string BobAliceSharedKeyText
    {
      get { return _bobAliceSharedKeyText; }
      set {
        _bobAliceSharedKeyText = value;
        NotifyPropertyChanged("BobAliceSharedKeyText");
      }
    }

    byte[] aliceRandomBytes;
    byte[] alicePrivateBytes;
    byte[] alicePublicBytes;

    byte[] bobRandomBytes;
    byte[] bobPrivateBytes;
    byte[] bobPublicBytes;

    byte[] aliceBobSharedBytes;
    byte[] bobAliceSharedBytes;

    public void GenAliceRandomFunc(object obj)
    {
      alicePrivateBytes = null;
      AlicePrivateKeyText = "";

      alicePublicBytes = null;
      AlicePublicKeyText = "";

      aliceBobSharedBytes = null;
      bobAliceSharedBytes = null;

      AliceBobSharedKeyText = "";
      BobAliceSharedKeyText = "";

      aliceRandomBytes = new byte[32];
      RNGCryptoServiceProvider.Create().GetBytes(aliceRandomBytes);
      AliceRandomText = BitConverter.ToString(aliceRandomBytes).Replace("-","");
    }

    public void ComputeAlicePrivateFromRandomFunc(object obj)
    {
      if (aliceRandomBytes != null)
        {
          alicePrivateBytes = Curve25519.ClampPrivateKey(aliceRandomBytes);
          AlicePrivateKeyText = BitConverter.ToString(alicePrivateBytes).Replace("-","");
        }
    }

    public void ComputeAlicePublicFromPrivateFunc(object obj)
    {
      if (alicePrivateBytes != null)
        {
          alicePublicBytes = Curve25519.GetPublicKey(alicePrivateBytes);
          AlicePublicKeyText = BitConverter.ToString(alicePublicBytes).Replace("-","");
        }
    }

    public void GenBobRandomFunc(object obj)
    {
      bobPrivateBytes = null;
      BobPrivateKeyText = ""; // Reset

      bobPublicBytes = null;
      BobPublicKeyText = ""; // Reset

      aliceBobSharedBytes = null;
      bobAliceSharedBytes = null;

      AliceBobSharedKeyText = "";
      BobAliceSharedKeyText = "";

      bobRandomBytes = new byte[32];
      RNGCryptoServiceProvider.Create().GetBytes(bobRandomBytes);
      BobRandomText = BitConverter.ToString(bobRandomBytes).Replace("-","");
    }

    public void ComputeBobPrivateFromRandomFunc(object obj)
    {
      if (bobRandomBytes != null)
        {
          bobPrivateBytes = Curve25519.ClampPrivateKey(bobRandomBytes);
          BobPrivateKeyText = BitConverter.ToString(bobPrivateBytes).Replace("-","");
        }
    }

    public void ComputeBobPublicFromPrivateFunc(object obj)
    {
      if (bobPrivateBytes != null)
        {
          bobPublicBytes = Curve25519.GetPublicKey(bobPrivateBytes);
          BobPublicKeyText = BitConverter.ToString(bobPublicBytes).Replace("-","");
        }
    }

    public void computeAliceBobSharedFunc(object obj)
    {
      if ( (alicePrivateBytes != null) && (bobPublicBytes != null) )
        {
          aliceBobSharedBytes = Curve25519.GetSharedSecret(alicePrivateBytes, bobPublicBytes);
          AliceBobSharedKeyText = BitConverter.ToString(aliceBobSharedBytes).Replace("-","");
        }
    }

    public void computeBobAliceSharedFunc(object obj)
    {

      if ( (bobPrivateBytes != null) && (alicePublicBytes != null) )
        {
          bobAliceSharedBytes = Curve25519.GetSharedSecret(bobPrivateBytes, alicePublicBytes);
          BobAliceSharedKeyText = BitConverter.ToString(bobAliceSharedBytes).Replace("-","");
        }
    }

    public MainWindowViewModel()
    {
      // Add RelayCommands here
      GenAliceRandomCommand = new RelayCommand(GenAliceRandomFunc, param => this.canExecute);

      ComputeAlicePrivateFromRandomCommand = new RelayCommand(ComputeAlicePrivateFromRandomFunc, param => this.canExecute);

      ComputeAlicePublicFromPrivateCommand = new RelayCommand(ComputeAlicePublicFromPrivateFunc, param => this.canExecute);

      GenBobRandomCommand = new RelayCommand(GenBobRandomFunc, param => this.canExecute);

      ComputeBobPrivateFromRandomCommand = new RelayCommand(ComputeBobPrivateFromRandomFunc, param => this.canExecute);

      ComputeBobPublicFromPrivateCommand = new RelayCommand(ComputeBobPublicFromPrivateFunc, param => this.canExecute);

      ComputeAliceBobSharedCommand = new RelayCommand(computeAliceBobSharedFunc, param => this.canExecute);

      ComputeBobAliceSharedCommand = new RelayCommand(computeBobAliceSharedFunc, param => this.canExecute);

    }

    private bool canExecute = true;

    public void ChangeCanExecute(object obj)
    {
      canExecute = !canExecute;
    }

  }
}
