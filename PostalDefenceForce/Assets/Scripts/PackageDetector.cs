using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageDetector : MonoBehaviour
{
    // Assign package to look for using a package class with package ID variable
    // if package ID == requiredPackageID then add score
    // if package ID != requiredPackageID then... minus score?
    // if correct package then wait for seconds then remove object so that shelf is empty
    // OR play animation where package is sucked into a distribution channel. Tubes
    // instead of ingredients, package weights?
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Carryable") {
            print("package detected");
        }
    }
}
