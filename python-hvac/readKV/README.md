# python-vault-basic

this is a simple python3 script that: 

* logs into Vault
* reading a static secret

## Pre requisites

we are using the HVAC python vault library to facilitate interacting with Vault, for this we will need to install the prerequisites, you can do this with pip by running the following command:

```bash
pip install -r requirements.txt
```

this script also expects vault related to the address, token and namespace. you can set these by running the following command:

```bash
export VAULT_ADDR=http://localhost:8200
export VAULT_TOKEN=root
export VAULT_NAMESPACE=example
```

please note: if not using namespaces,  leave it blank. 
]
