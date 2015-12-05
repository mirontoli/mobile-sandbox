//
//  ViewController.swift
//  Hello Beacon
//  Followed along this video: Beacon with Swift: https://www.youtube.com/watch?v=3jJiqzbzutU
//
//  Created by Anatoly Mironov on 05/12/15.
//  Copyright © 2015 A Chuvash Guy. All rights reserved.
//
//

import UIKit
import CoreLocation


class ViewController: UIViewController, CLLocationManagerDelegate {
    let ourBeacons: [NSNumber: String] = [54199: "Anatoly", 3872: "Henric", 16843: "David", 53503: "Jocke", 15946: "Mattias", 56349: "Johannes"]

    @IBOutlet weak var labelHello: UILabel!
    
    let locationManager = CLLocationManager()
    let region = CLBeaconRegion(proximityUUID: NSUUID(UUIDString: "B9407F30-F5F8-466E-AFF9-25556B57FE6D")!, identifier: "Estimotes")
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        locationManager.delegate = self
        if(CLLocationManager.authorizationStatus() != CLAuthorizationStatus.AuthorizedWhenInUse) {
            locationManager.requestWhenInUseAuthorization()
        }
        locationManager.startRangingBeaconsInRegion(region)
        
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func locationManager(manager: CLLocationManager, didRangeBeacons beacons: [CLBeacon], inRegion region: CLBeaconRegion) {
        //var b = beacons[0]
        let knownBeacons = beacons.filter{$0.proximity != CLProximity.Unknown }
        if (knownBeacons.count > 0) {
            let closestBeacon = knownBeacons[0] as CLBeacon
            let beaconName = ourBeacons[closestBeacon.minor] ?? "Unknown beacon"
            
            labelHello.text = beaconName
        }
        else {
            labelHello.text = "Nothing found"
        }
    }


}

